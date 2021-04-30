using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.BL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionnarieId { get; set; }

        //nav
        public QuestionnarieDTO Questionnarie { get; set; }
        public List<AnswerVariantDTO> AnswerVariants { get; set; }
        public List<AnswerDTO> Answers { get; set; }
    }
}
