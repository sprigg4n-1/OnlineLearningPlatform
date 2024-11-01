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
    public class TestQuestionSeeder : ISeeder<TestQuestionEntity>
    {
        private static readonly List<TestQuestionEntity> tests = new()
        {
            new TestQuestionEntity
                {
                    Id = 1,
                    QuestionText = "Що таке змінна в C#?",
                    TestId = 1,
                },

            new TestQuestionEntity
                {
                    Id = 2,
                    QuestionText = "Яка з цих конструкцій є циклом у C#?",
                    TestId = 1,
                },

            new TestQuestionEntity
                {
                    Id = 3,
                    QuestionText = "Що таке клас у об'єктно-орієнтованому програмуванні?",
                    TestId = 1,
                },
            new TestQuestionEntity
                {
                    Id = 4,
                    QuestionText = "Що таке алгоритм?",
                    TestId = 2,
                },
            new TestQuestionEntity
                {
                    Id = 5,
                    QuestionText = "Яка структура даних є найкращою для реалізації стеку?",
                    TestId = 2,
                },
            new TestQuestionEntity
                {
                    Id = 6,
                    QuestionText = "Що таке складність алгоритму?",
                    TestId = 2,
                }
        };

        public void Seed(EntityTypeBuilder<TestQuestionEntity> builder) => builder.HasData(tests);
    }
}
