using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.DAL.Interfaces;
using Digital_Library.DAL.Repositories;
using Digital_Library.BL.Interfaces;

namespace Digital_Library.BL.Services
{
    /// <summary>
    /// Services factory for create services without IoC container
    /// </summary>
    public class ServiceCreator : IServiceCreator
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor create unit of work object
        /// </summary>
        public ServiceCreator()
        {
            _unitOfWork = new EFUnitOfWork("DefaultConnection");
        }

        public IPostsService CreatePostService() => new PostService(_unitOfWork);
        public ICommentsSerice CreateCommentService() => new CommentService(_unitOfWork);
        public IQestionnarieService CreatyeQestionnarieService() => new QuestionnarieService(_unitOfWork); 
    }
}
