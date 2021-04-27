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
    public class PostsRepository : IRepository<Post>
    {
        private readonly ApplicationContext _db;

        public PostsRepository (ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Post item)
        {
            _db.Posts.Add(item);
        }

        public bool Delete(int id)
        {
            Post post = _db.Posts.Find(id);
            if(post is object)
            {
                _db.Posts.Remove(post);
                return true;
            }
            return false;
        }

        public IQueryable<Post> Find(Func<Post, bool> predicate)
        {
            return _db.Posts.Where(predicate).AsQueryable();
        }

        public Post Get(int id)
        {
            return _db.Posts.Find(id);
        }

        public IQueryable<Post> GetAll()
        {
            return _db.Posts;
        }

        public void Update(Post item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
