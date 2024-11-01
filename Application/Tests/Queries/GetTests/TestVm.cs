using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tests.Queries.GetTests
{
    public class TestVm : IMapFrom<TestEntity>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TimeLimit { get; set; }
        public int CourseId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TestEntity, TestVm>();
        }
    }
}
