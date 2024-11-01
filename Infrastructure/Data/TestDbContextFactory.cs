using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        public TestDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();

            optionsBuilder.UseSqlServer("Data Source=WINDOWS-05UFGJN;Initial Catalog=tests-course;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

            return new TestDbContext(optionsBuilder.Options);
        }
    }
}
