﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Digital_Library.BL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Digital_Library.PL.Models
{
    public class QuestionnariesViewModel
    {
        public IEnumerable<QuestionnarieDTO> Questionnaries { get; set; }
        public QuestionnarieDTO NewQuestionnarie { get; set; }
    }
}