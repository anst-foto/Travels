using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travels.Models;

namespace Travels.DAL;

public class PointRepositoryPostgres : IPointRepository
{
    public IAsyncEnumerable<Point> GetPointsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Point?> GetPointByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task AddPointAsync(Point point)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePointAsync(Point point)
    {
        throw new NotImplementedException();
    }
}
