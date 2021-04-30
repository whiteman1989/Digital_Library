using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.DAL.Entities
{
    public class AnswerVariant
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public virtual Question Question { get; set; }
    }
}
