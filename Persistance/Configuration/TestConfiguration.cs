using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Seeding;

namespace Persistance.Configuration
{
    public class TestConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);  

            builder.Property(t => t.Description)
                .HasMaxLength(500);



            builder.HasMany(t => t.Questions)
                   .WithOne(q => q.Test)
                   .HasForeignKey(q => q.TestId)
                   .OnDelete(DeleteBehavior.Cascade);

            new TestSeeder().Seed(builder);
        }
    }
}
