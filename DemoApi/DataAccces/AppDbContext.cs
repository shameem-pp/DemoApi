using DemoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace DemoApi.DataAccces;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Demo> Demos { get; set; }

}
