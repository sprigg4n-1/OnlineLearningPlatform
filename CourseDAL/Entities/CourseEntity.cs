﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDAL.Entities
{
    public class CourseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int Rate { get; set; }
        public string Level { get; set; }
        public int AuthorId { get; set; }
    }
}
