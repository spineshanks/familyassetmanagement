using Microsoft.EntityFrameworkCore;

namespace FamilyAssetManagement;

public class FamilyAssetManagementDbContext : DbContext
{
    public FamilyAssetManagementDbContext(DbContextOptions<FamilyAssetManagementDbContext> options) : base(options)
    {

    }
    public DbSet<Person> Person { get; set; }
}