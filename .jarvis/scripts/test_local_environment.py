"""Verificações de propriedade e recuperação, sem usar Docker ou dados do produto."""
import argparse
import importlib.util
import json
from pathlib import Path
import socket
import subprocess
import sys
import tempfile
import unittest
from unittest.mock import patch

spec = importlib.util.spec_from_file_location('local_environment', Path(__file__).with_name('local_environment.py'))
local = importlib.util.module_from_spec(spec)
spec.loader.exec_module(local)


class LocalEnvironmentTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.runtime = patch.object(local, 'RUNTIME', Path(self.temp.name))
        self.runtime.start()
        self.addCleanup(self.runtime.stop)

    def state(self):
        return {'repo': str(local.ROOT), 'processes': [], 'containers': []}

    def sleeper(self):
        process = subprocess.Popen([sys.executable, '-c', 'import time; time.sleep(60)'], start_new_session=True)
        def cleanup():
            if process.poll() is None:
                process.terminate()
            process.wait(timeout=5)
        self.addCleanup(cleanup)
        return process

    def test_stop_owned_process_preserves_unrelated_process(self):
        owned, foreign = self.sleeper(), self.sleeper()
        local.stop_process({'pid': owned.pid, 'identity': local.process_identity(owned.pid)})
        owned.wait(timeout=5)
        self.assertIsNone(foreign.poll())

    def test_pid_with_different_identity_receives_no_signal(self):
        foreign = self.sleeper()
        with patch.object(local.os, 'killpg') as kill:
            with self.assertRaises(local.LocalError):
                local.stop_process({'pid': foreign.pid, 'identity': 'identidade de processo anterior'})
            kill.assert_not_called()
        self.assertIsNone(foreign.poll())

    def test_running_container_is_reused_without_ownership(self):
        state = self.state()
        with patch.object(local, 'compose', return_value='existing') as compose, patch.object(
            local, 'container_info', return_value={'State': {'Running': True}}
        ):
            local.ensure_container('catalog-db', {'name': 'project'}, state)
        self.assertEqual([], state['containers'])
        compose.assert_called_once_with('ps', '--all', '--quiet', 'catalog-db')

    def test_container_started_here_is_recorded_without_secrets_and_stopped(self):
        state = self.state()
        info = {'State': {'Running': True, 'Health': {'Status': 'healthy'}}, 'Config': {'Labels': {
            'com.docker.compose.project': 'project', 'com.docker.compose.service': 'catalog-db'}}}
        with patch.object(local, 'compose', side_effect=['', '', 'owned', 'owned']), patch.object(
            local, 'container_info', return_value=info
        ):
            local.ensure_container('catalog-db', {'name': 'project', 'secret': 'must-not-be-saved'}, state)
        persisted = (Path(self.temp.name) / 'state.json').read_text()
        self.assertNotIn('must-not-be-saved', persisted)
        with patch.object(local, 'container_info', return_value=info), patch.object(local, 'command') as command:
            local.shutdown(state)
        command.assert_called_once_with(['docker', 'stop', '--time', '10', 'owned'])
        self.assertFalse((Path(self.temp.name) / 'state.json').exists())

    def test_partial_container_start_keeps_ownership_for_cleanup(self):
        state = self.state()
        with patch.object(local, 'compose', side_effect=['', local.LocalError('up failed'), 'partial']):
            with self.assertRaises(local.LocalError):
                local.ensure_container('catalog-db', {'name': 'project'}, state)
        self.assertEqual('partial', state['containers'][0]['id'])
        self.assertEqual(state, json.loads((Path(self.temp.name) / 'state.json').read_text()))

    def test_wrong_container_labels_preserve_resource_and_pending_state(self):
        state = self.state()
        state['containers'] = [{'id': 'foreign', 'service': 'catalog-db', 'project': 'expected'}]
        with patch.object(local, 'container_info', return_value={'Config': {'Labels': {
            'com.docker.compose.project': 'another-project'}}}), patch.object(local, 'command') as command:
            with self.assertRaises(local.LocalError):
                local.shutdown(state)
            command.assert_not_called()
        self.assertEqual(1, len(state['containers']))

    def test_occupied_port_does_not_start_or_kill_resources(self):
        with socket.socket() as listener:
            listener.bind(('127.0.0.1', 0))
            listener.listen()
            args = argparse.Namespace(port=listener.getsockname()[1], identity=False, no_seed=True)
            with patch.object(local, 'command') as command:
                with self.assertRaises(local.LocalError):
                    local.start(args, self.state())
                command.assert_not_called()

    def test_repeated_start_reuses_ready_api(self):
        state = self.state()
        state.update(url='http://127.0.0.1:5080', processes=[{'pid': 999, 'identity': 'same'}])
        args = argparse.Namespace(identity=False)
        with patch.object(local, 'process_identity', return_value='same'), patch.object(
            local, 'ready', return_value=True
        ), patch.object(local, 'command') as command:
            local.start(args, state)
            command.assert_not_called()


if __name__ == '__main__':
    unittest.main()
