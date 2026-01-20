using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travels.Models;

namespace Travels.DAL;

public class PointRepositoryPostgres : IPointRepository
{
    private DataBaseContext _context;
    public PointRepositoryPostgres(string connectionString)
    {
        _context = DataBaseContextFactory.CreateDbContext(connectionString);
    }

    public IAsyncEnumerable<Point> GetPointsAsync() =>
        _context.Points.AsAsyncEnumerable();

    public async Task<Point?> GetPointByIdAsync(Guid id) => await
        _context.Points.SingleOrDefaultAsync(p => p.Id == id);

    public async Task AddPointAsync(Point point)
    {
        await _context.Points.AddAsync(point);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePointAsync(Point point)
    {
        _context.Points.Update(point);
        await _context.SaveChangesAsync();
    }
}
