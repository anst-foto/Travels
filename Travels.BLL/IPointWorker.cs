using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travels.Models;

namespace Travels.BLL;

public interface IPointWorker
{
    public IAsyncEnumerable<Point> GetPointsAsync();
    public Task<Point?> GetPointByIdAsync(Guid id);
    public Task AddPointAsync(Point point);
    public Task UpdatePointAsync(Point point);
}
