using FluentValidation;

namespace ReviewVerse.Application.Game.Commands.CreateGame;

public class CreateGameValidation : AbstractValidator<CreateGameCommand>
{
    public CreateGameValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(200)
            .WithMessage("Name must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(2000)
            .WithMessage("Description must not exceed 2000 characters.");
    }
}
