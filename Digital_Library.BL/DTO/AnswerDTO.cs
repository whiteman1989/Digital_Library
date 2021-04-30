using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.BL.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        //navs
        public QuestionDTO Question { get; set; }
    }
}
