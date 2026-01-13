using Travels.DAL;

namespace Travels.BLL;

public class PointWorkerPostgres : PointWorkerWithLog, IPointWorker
{
    private static readonly IPointRepository PointRepository =
        new PointRepositoryPostgres();

    public PointWorkerPostgres() : base(PointRepository)
    {
    }


}
