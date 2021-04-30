﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.DAL.Entities
{
    public class Questionnarie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }

        //nav
        public virtual List<Question> Questions { get; set; }
    }
}
