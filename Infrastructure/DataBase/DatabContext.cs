using Microsoft.EntityFrameworkCore;
using Minimal_API.Domain.Entities;

namespace Minimal_API.Infrastructure.DataBase;

public class DatabContext : DbContext{
    private readonly IConfiguration _configAppSettings;
    public DatabContext(IConfiguration configAppSettings){
        _configAppSettings = configAppSettings;
    }

    public DbSet<Admin> Admins {get; set;} = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var stringConnection = _configAppSettings.GetConnectionString("mysql").ToString();
        if (!string.IsNullOrEmpty(stringConnection)){
            optionsBuilder.UseMySql("connection string", ServerVersion.AutoDetect("connection string"));
        }
        
    }
}