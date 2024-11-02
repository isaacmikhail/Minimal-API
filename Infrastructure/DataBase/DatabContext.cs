using Microsoft.EntityFrameworkCore;
using Minimal_API.Domain.Entities;

namespace Minimal_API.Infrastructure.DataBase;

public class DatabContext : DbContext{

    public DbSet<Admin> Admins {get; set;} = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("connection string", ServerVersion.AutoDetect("connection string"));
    }
}