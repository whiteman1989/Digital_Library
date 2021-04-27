using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digital_Library.BL.Interfaces;
using Digital_Library.DAL.Interfaces;
using Digital_Library.DAL.Entities;
using Digital_Library.BL.DTO;
using Digital_Library.BL.Infrastructure;
using AutoMapper;

namespace Digital_Library.BL.Services
{
    public class PostService : IPostsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var mapperConfig = new MapperConfiguration(cfg => 
                cfg.CreateMap<PostDTO, Post>().ReverseMap());

            _mapper = new Mapper(mapperConfig);
        }

        public void AddPost(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            _unitOfWork.Posts.Create(post);
        }

        public void DeletePost(int id)
        {
            if(!_unitOfWork.Posts.Delete(id))
            {
                throw new ValidationException("No post with this id", "id");
            }
        }

        public void EditPost(PostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);
            _unitOfWork.Posts.Update(post);
        }

        public PostDTO GetPost(int id)
        {
            var postDTO = _mapper.Map<PostDTO>(_unitOfWork.Posts.Get(id));
            if(postDTO is null)
            {
                throw new ValidationException("No post with this id", "id");
            }
            else
            {
                return postDTO;
            }
        }

        public IEnumerable<PostDTO> GetPosts()
        {
            var postsDTo = _mapper.Map<IEnumerable<PostDTO>>(_unitOfWork.Posts.GetAll());
            return postsDTo;
        }

        public IEnumerable<PostDTO> GetPosts(int pageSize, int page)
        {
            var posts = _unitOfWork.Posts.GetAll().Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
            if (!posts.Any()) throw new ValidationException("this page is empty", nameof(page));
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public int PageCount(int pageSize)
        {
            var count = _unitOfWork.Posts.GetAll().Count();
            return (count / pageSize) + ((count % pageSize) > 0 ? 1 : 0);
        }
    }
}
