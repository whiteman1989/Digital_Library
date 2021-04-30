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
    public class QuestionsRepository : IRepository<Question>
    {
        private readonly ApplicationContext _db;

        public QuestionsRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Question item)
        {
            _db.Questions.Add(item);
        }

        public bool Delete(int id)
        {
            Question question = _db.Questions.Find(id);
            if (question is object)
            {
                _db.Questions.Remove(question);
                return true;
            }
            return false;
        }

        public IQueryable<Question> Find(Func<Question, bool> predicate)
        {
            return _db.Questions.Where(predicate).AsQueryable();
        }

        public Question Get(int id)
        {
            return _db.Questions.Find(id);
        }

        public IQueryable<Question> GetAll()
        {
            return _db.Questions;
        }

        public void Update(Question item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
