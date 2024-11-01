using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TestQuestionEntity
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int TestId { get; set; }
        public TestEntity Test { get; set; }
    }
}
