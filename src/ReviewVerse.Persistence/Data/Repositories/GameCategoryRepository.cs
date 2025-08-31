using Microsoft.EntityFrameworkCore;
using ReviewVerse.Domain.Entities;
using ReviewVerse.Domain.Repositories;

namespace ReviewVerse.Persistence.Data.Repositories;

public class GameCategoryRepository : IGameCategoryRepository
{
    private readonly AppDbContext _context;

    public GameCategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GameCategory> AddAsync(GameCategory entity)
    {
        _context.GameCategories.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(GameCategory entity)
    {
        _context.GameCategories.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<GameCategory?> GetByIdAsync(int id)
    {
        return await _context.GameCategories.FindAsync(id);
    }

    public async Task<IEnumerable<GameCategory>> ListAllAsync()
    {
        return await _context.GameCategories.ToListAsync();
    }

    public async Task UpdateAsync(GameCategory entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
