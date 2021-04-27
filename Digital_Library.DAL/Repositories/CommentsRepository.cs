using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Digital_Library.DAL.Interfaces;
using Digital_Library.DAL.Entities;
using Digital_Library.DAL.Data;

namespace Digital_Library.DAL.Repositories
{
    class CommentsRepository : IRepository<Comment>
    {
        private readonly ApplicationContext _db;

        public CommentsRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Comment item)
        {
            _db.Comments.Add(item);
        }

        public bool Delete(int id)
        {
            Comment comment = _db.Comments.Find(id);
            if (comment is object)
            {
                _db.Comments.Remove(comment);
                return true;
            }
            return false;
        }

        public IQueryable<Comment> Find(Func<Comment, bool> predicate)
        {
            return _db.Comments.Where(predicate).AsQueryable();
        }

        public Comment Get(int id)
        {
            return _db.Comments.Find(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return _db.Comments;
        }

        public void Update(Comment item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
