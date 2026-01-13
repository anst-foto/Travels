using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travels.Models;

namespace Travels.DAL;

public interface IPointRepository
{
    public IAsyncEnumerable<Point> GetPointsAsync();
    public Task<Point?> GetPointByIdAsync(Guid id);

    public Task AddPointAsync(Point point);
    public Task UpdatePointAsync(Point point);
}
