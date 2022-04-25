using System;
using Microsoft.EntityFrameworkCore;

namespace MySqlJsonTest;

public class SampleDbContext : DbContext
{
    public SampleDbContext()
        : base()
    {
    }

    public SampleDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<EntityWithJson> Entities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=test;uid=root;password=root;Convert Zero Datetime=True;charset=utf8;",
                new MySqlServerVersion(new Version(5, 7, 26)),
                x => x.UseNewtonsoftJson(MySqlCommonJsonChangeTrackingOptions.FullHierarchyOptimizedSemantically));

        base.OnConfiguring(optionsBuilder);
    }
}