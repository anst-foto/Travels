using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travels.DAL;
using Travels.Models;

namespace Travels.BLL;

public class PointWorkerBase : IPointWorker
{
    private readonly IPointRepository _pointRepository;

    public PointWorkerBase(IPointRepository pointRepository)
    {
        _pointRepository = pointRepository;
    }

    public IAsyncEnumerable<Point> GetPointsAsync() =>
        _pointRepository.GetPointsAsync();

    public async Task<Point?> GetPointByIdAsync(Guid id) =>
        await _pointRepository.GetPointByIdAsync(id);

    public async Task AddPointAsync(Point point) =>
        await _pointRepository.AddPointAsync(point);

    public async Task UpdatePointAsync(Point point) =>
        await _pointRepository.UpdatePointAsync(point);

    public async Task DeletePointAsync(Guid id)
    {
        var point = await _pointRepository.GetPointByIdAsync(id);
        if (point is null) return; // TODO: throw exception?

        var deletedPoint = point with { IsDeleted = true };
        await _pointRepository.UpdatePointAsync(deletedPoint);
    }
}
