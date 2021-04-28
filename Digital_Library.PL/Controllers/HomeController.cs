using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Interfaces;
using Digital_Library.BL.Services;

namespace Digital_Library.PL.Controllers
{
    public class HomeController : Controller
    {
        private IServiceCreator _serviceCreator;
        private IPostsService _postsService;

        public HomeController()
        {
            _serviceCreator = new ServiceCreator();
            _postsService = _serviceCreator.CreatePostService();
        }

        public ActionResult Index()
        {
            var posts = _postsService.GetPosts();
            return View(posts);
        }

    }
}