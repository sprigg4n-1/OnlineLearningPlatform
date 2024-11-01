using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Configuration;

namespace Infrastructure.Data
{
    public class TestDbContext: DbContext
    {

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<TestQuestionEntity> TestsQuestion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new TestQuestionConfiguration());
        }



    }
}
