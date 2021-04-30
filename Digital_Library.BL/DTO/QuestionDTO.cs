using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.DAL.Entities;

namespace Digital_Library.BL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionnarieId { get; set; }
        public QuestionType QuestionType { get; set; }

        //nav
        public QuestionnarieDTO Questionnarie { get; set; }
        public List<AnswerVariantDTO> AnswerVariants { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}
