using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Seeding.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Seeding
{
    public class TestSeeder : ISeeder<TestEntity>
    {
        private static readonly List<TestEntity> tests = new()
        {
            new TestEntity
                {
                    Id = 2,
                    Title = "Поглиблене вивчення C#",
                    Description = "Курс призначений для студентів, які хочуть глибше зануритися в мову C#.",
                    TimeLimit = 100,
                    CourseId = 2
                },

            new TestEntity
                {
                    Id = 1,
                    Title = "Вступ до програмування",
                    Description = "Цей курс знайомить студентів з основами програмування, використовуючи C#.",
                    TimeLimit = 120,
                    CourseId = 1
            }
        };

        public void Seed(EntityTypeBuilder<TestEntity> builder) => builder.HasData(tests);
    }
}
