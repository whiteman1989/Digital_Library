using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Digital_Library.BL.Interfaces;
using Digital_Library.BL.Services;

[assembly: OwinStartup(typeof(Digital_Library.PL.App_Start.Startup))]

namespace Digital_Library.PL.App_Start
{
    public class Startup
    {
        private readonly IServiceCreator _serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            
        }

        private IPostsService CreatePostService()
        {
            return _serviceCreator.CreatePostService();
        }

        private ICommentsSerice CreateCommentService()
        {
            return _serviceCreator.CreateCommentService();
        }
    }
}
