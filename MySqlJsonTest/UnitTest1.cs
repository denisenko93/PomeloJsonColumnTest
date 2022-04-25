using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace MySqlJsonTest;

public class Tests
{
    private SampleDbContext _dbContext;

    [SetUp]
    public void Setup()
    {
        _dbContext = new SampleDbContext();

        _dbContext.Database.EnsureCreated();
    }

    [Test]
    public async Task Test1()
    {
        _dbContext.Entities.Add(new EntityWithJson
        {
            Json = new SampleJson()
            {
                IntValue = 34546
            }
        });

        await _dbContext.SaveChangesAsync();

        var query = _dbContext.Entities
            .Select(x => new Projection
            {
                Value = x.Id,
                JsonValue = x.Json.IntValue
            });
        await query.ToArrayAsync();
    }

    class Projection
    {
        public int Value { get; set; }

        public int JsonValue { get; set; }
    }
}