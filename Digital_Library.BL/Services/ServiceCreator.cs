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
    public class ServiceCreator : IServiceCreator
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceCreator()
        {
            _unitOfWork = new EFUnitOfWork("DefaultConnection");
        }

        public IPostsService CreatePostService() => new PostService(_unitOfWork);
        public ICommentsSerice CreateCommentService() => new CommentService(_unitOfWork);
    }
}
