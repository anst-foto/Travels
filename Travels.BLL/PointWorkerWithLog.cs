using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travels.DAL;
using Travels.Models;

namespace Travels.BLL;

public class PointWorkerWithLog : PointWorkerBase
{
    public PointWorkerWithLog(IPointRepository pointRepository)
        : base(pointRepository)
    { }

    public IAsyncEnumerable<Point> GetPointsAsync()
    {
        Console.WriteLine("GetPointsAsync");
        return base.GetPointsAsync();
    }

    public async Task<Point?> GetPointByIdAsync(Guid id)
    {
        Console.WriteLine("GetPointByIdAsync");
        return await base.GetPointByIdAsync(id);
    }


    public async Task AddPointAsync(Point point)
    {
        Console.WriteLine("AddPointAsync");
        await base.AddPointAsync(point);
    }

    public async Task UpdatePointAsync(Point point)
    {
        Console.WriteLine("UpdatePointAsync");
        await base.UpdatePointAsync(point);
    }

    public async Task DeletePointAsync(Guid id)
    {
        Console.WriteLine("DeletePointAsync");
        await base.DeletePointAsync(id);
    }
}
