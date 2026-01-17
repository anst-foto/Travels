using Microsoft.EntityFrameworkCore;
using Travels.Models;

namespace Travels.DAL;

public class DataBaseContext : DbContext
{
    public DbSet<Point> Points { get; set; }

    public DataBaseContext(DbContextOptions<DataBaseContext> options) :
        base(options) { }
}
