using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.BL.DTO
{
    public class AnswerVariantDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public QuestionDTO Question { get; set; }
    }
}
