using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Persistance.Seeding;

namespace Persistance.Configuration
{
    public class TestQuestionConfiguration : IEntityTypeConfiguration<TestQuestionEntity>
    {
        public void Configure(EntityTypeBuilder<TestQuestionEntity> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.QuestionText)
                .IsRequired()
                .HasMaxLength(300);  

            builder.HasOne(q => q.Test)
                   .WithMany(t => t.Questions)
                   .HasForeignKey(q => q.TestId)
                   .OnDelete(DeleteBehavior.Cascade); 


            new TestQuestionSeeder().Seed(builder);
        }
    }
}
