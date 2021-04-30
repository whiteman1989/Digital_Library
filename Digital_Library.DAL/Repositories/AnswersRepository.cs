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
    class AnswersRepository : IRepository<Answer>
    {
        private readonly ApplicationContext _db;

        public AnswersRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Answer item)
        {
            _db.Answers.Add(item);
        }

        public bool Delete(int id)
        {
            Answer answer = _db.Answers.Find(id);
            if (answer is object)
            {
                _db.Answers.Remove(answer);
                return true;
            }
            return false;
        }

        public IQueryable<Answer> Find(Func<Answer, bool> predicate)
        {
            return _db.Answers.Where(predicate).AsQueryable();
        }

        public Answer Get(int id)
        {
            return _db.Answers.Find(id);
        }

        public IQueryable<Answer> GetAll()
        {
            return _db.Answers;
        }

        public void Update(Answer item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
