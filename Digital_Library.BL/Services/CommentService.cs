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
    class CommentService : ICommentsSerice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var mapperConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<CommetDTO, Comment>().ReverseMap());

            _mapper = new Mapper(mapperConfig);
        }

        public void AddComment(CommetDTO commetDTO)
        {
            var comment = _mapper.Map<Comment>(commetDTO);
            _unitOfWork.Comments.Create(comment);
            _unitOfWork.Save();
        }

        public void DeleteComent(int id)
        {
            if (!_unitOfWork.Comments.Delete(id))
            {
                throw new ValidationException("No comment with this id", "id");
            }
            _unitOfWork.Save();
        }

        public CommetDTO GetComment(int id)
        {
            var commetDTO = _mapper.Map<CommetDTO>(_unitOfWork.Comments.Get(id));
            if (commetDTO is null)
            {
                throw new ValidationException("No comment with this id", "id");
            }
            else
            {
                return commetDTO;
            }
        }

        public IEnumerable<CommetDTO> GetComments()
        {
            var commentDTO = _mapper.Map<IEnumerable<CommetDTO>>(_unitOfWork.Comments.GetAll().AsEnumerable());
            return commentDTO;
        }

        public IEnumerable<CommetDTO> GetComments(int pageSize, int page)
        {
            var comments = _unitOfWork.Comments.GetAll().Skip((page - 1) * pageSize).Take(pageSize).AsEnumerable();
            if (!comments.Any()) throw new ValidationException("this page is empty", nameof(page));
            return _mapper.Map<IEnumerable<CommetDTO>>(comments);
        }

        public int PageCount(int pageSize)
        {
            var count = _unitOfWork.Comments.GetAll().Count();
            return (count / pageSize) + ((count % pageSize) > 0 ? 1 : 0);
        }

        public void UodateComment(CommetDTO commetDTO)
        {
            var comment = _mapper.Map<Comment>(commetDTO);
            _unitOfWork.Comments.Update(comment);
            _unitOfWork.Save();
        }
    }
}
