using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Digital_Library.BL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Digital_Library.PL.Models
{
    public class ResultViewModel
    {
        public QuestionnarieDTO Questionnarie { get; set; }
        public List<QuestionStats> QuestionStats { get; set; }
    }
}