using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Library.DAL.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionnarieId { get; set; }
        public QuestionType QuestionType { get; set; }

        //nav
        public virtual Questionnarie Questionnarie { get; set; }
        public virtual List<AnswerVariant> AnswerVariants { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }

    public enum QuestionType
    {
        TextBox,
        RadioButtons,
        CheckBoxes,
    }
}
