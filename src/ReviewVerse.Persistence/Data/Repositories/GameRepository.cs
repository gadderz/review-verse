using Microsoft.EntityFrameworkCore;
using ReviewVerse.Domain.Entities;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Persistence.Data.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Game> AddAsync(Game entity)
    {
        _context.Games.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Game entity)
    {
        entity.DeletedAt = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _context.Games.FirstOrDefaultAsync(f => f.Id == id && f.DeletedAt == null);
    }

    public async Task<IEnumerable<Game>> ListAllAsync()
    {
        return await _context.Games.Where(w => w.DeletedAt != null).ToListAsync();
    }

    public async Task UpdateAsync(Game entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
