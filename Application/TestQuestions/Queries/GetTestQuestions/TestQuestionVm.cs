using Application.Common.Mappings;
using Application.Tests.Queries.GetTests;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TestQuestions.Queries.GetTestQuestions
{
    public class TestQuestionVm : IMapFrom<TestQuestionEntity>
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TestQuestionEntity, TestQuestionVm>();
        }
    }
}
