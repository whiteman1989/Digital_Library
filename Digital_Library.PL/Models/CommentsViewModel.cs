using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Digital_Library.BL.DTO;
using System.ComponentModel.DataAnnotations;

namespace Digital_Library.PL.Models
{
    public class CommentsViewModel
    {
        public IEnumerable<CommetDTO> Commets { get; set; }

        [Required(ErrorMessage = "Enter your name")]
        [Display(Name = "Your name")]
        public string NewCommentAuthor { get; set; }

        [Required(ErrorMessage = "Enter some text")]
        [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "Comment must be at least 10 characters long")]
        [Display(Name = "Comment")]
        public string NewCommentText { get; set; }
    }
}