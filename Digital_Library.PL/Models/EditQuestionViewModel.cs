using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Digital_Library.BL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Digital_Library.PL.Models
{
    public class EditQuestionViewModel
    {
        public QuestionDTO Question { get; set; }
        public AnswerVariantDTO NewAnsverVariant { get; set; }
    }
}