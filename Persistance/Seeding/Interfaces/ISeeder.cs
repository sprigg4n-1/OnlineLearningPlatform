using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistance.Seeding.Interfaces
{
    public interface ISeeder<T> where T : class
    {
        void Seed(EntityTypeBuilder<T> builder);
    }
}
