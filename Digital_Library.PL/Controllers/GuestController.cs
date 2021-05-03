using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Interfaces;
using Digital_Library.BL.Services;
using Digital_Library.PL.Models;

namespace Digital_Library.PL.Controllers
{
    public class GuestController : Controller
    {
        private readonly IServiceCreator _serviceCreator;
        private readonly ICommentsSerice _commentsSerice;

        public GuestController(IServiceCreator serviceCreator)
        {
            _serviceCreator = serviceCreator;
            _commentsSerice = _serviceCreator.CreateCommentService();
        }

        // GET: Guest
        public ActionResult Index()
        {
            var comments = _commentsSerice.GetComments();
            var viewModel = new CommentsViewModel();
            viewModel.Commets = comments;
            return View(viewModel);
        }

        // POST: Guest/Index
        [HttpPost]
        public ActionResult Index(CommentsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newComment = new CommetDTO
                {
                    Author = model.NewCommentAuthor,
                    Text = model.NewCommentText,
                    Date = DateTime.Now
                };
                _commentsSerice.AddComment(newComment);
            }
            else
            {
                var errors = new List<String>();
                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                ViewBag.Errors = errors;
            }
            var comments = _commentsSerice.GetComments();
            var viewModel = new CommentsViewModel();
            viewModel.Commets = comments;
            return PartialView("_CommentsPartial", viewModel);
        }
    }
}