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
    /// <summary>
    /// Implements Comment service
    /// </summary>
    public class CommentService : ICommentsSerice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        /// <summary>
        /// Constructor get UnitOfWork object
        /// </summary>
        /// <param name="unitOfWork">Unit Of Work</param>
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var mapperConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<CommentDTO, Comment>().ReverseMap());

            _mapper = new Mapper(mapperConfig);
        }

        public void AddComment(CommentDTO commetDTO)
        {
            var comment = _mapper.Map<Comment>(commetDTO);
            _unitOfWork.Comments.Create(comment);
            _unitOfWork.Save();
        }

        public void DeleteComment(int id)
        {
            if (!_unitOfWork.Comments.Delete(id))
            {
                throw new ValidationException("No comment with this id", "id");
            }
            _unitOfWork.Save();
        }

        public CommentDTO GetComment(int id)
        {
            var commetDTO = _mapper.Map<CommentDTO>(_unitOfWork.Comments.Get(id));
            if (commetDTO is null)
            {
                throw new ValidationException("No comment with this id", "id");
            }
            else
            {
                return commetDTO;
            }
        }

        public IEnumerable<CommentDTO> GetComments()
        {
            var commentDTO = _mapper.Map<IEnumerable<CommentDTO>>(_unitOfWork.Comments.GetAll().AsEnumerable());
            return commentDTO;
        }

        public IEnumerable<CommentDTO> GetComments(int pageSize, int page)
        {
            var comments = _unitOfWork.Comments.GetAll().Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
            if (!comments.Any()) throw new ValidationException("this page is empty", nameof(page));
            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public int PageCount(int pageSize)
        {
            var count = _unitOfWork.Comments.GetAll().Count();
            return (count / pageSize) + ((count % pageSize) > 0 ? 1 : 0);
        }

        public void UpdateComment(CommentDTO commetDTO)
        {
            var comment = _mapper.Map<Comment>(commetDTO);
            _unitOfWork.Comments.Update(comment);
            _unitOfWork.Save();
        }
    }
}
