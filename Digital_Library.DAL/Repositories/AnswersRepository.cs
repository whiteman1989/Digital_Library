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
    /// <summary>
    /// Implements IRepository interface for using with Entity Framework
    /// </summary>
    class AnswersRepository : IRepository<Answer>
    {
        private readonly ApplicationContext _db;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Db context</param>
        public AnswersRepository(ApplicationContext context)
        {
            _db = context;
        }

        /// <summary>
        /// Create new answer
        /// </summary>
        /// <param name="item">new answer</param>
        public void Create(Answer item)
        {
            _db.Answers.Add(item);
        }

        /// <summary>
        /// Delete answer by Id
        /// </summary>
        /// <param name="id">Unique ID of the answer</param>
        /// <returns>Returnt true if answer deleted</returns>
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

        /// <summary>
        /// Find answer that satisfy the conditions of the predicate
        /// </summary>
        /// <param name="predicate">Predicate used to filtering objects</param>
        /// <returns>Collection of answer from repository</returns>
        public IQueryable<Answer> Find(Func<Answer, bool> predicate)
        {
            return _db.Answers.Where(predicate).AsQueryable();
        }

        /// <summary>
        /// Get amswer by Id
        /// </summary>
        /// <param name="id">Unique ID of the answer</param>
        /// <returns>answer</returns>
        public Answer Get(int id)
        {
            return _db.Answers.Find(id);
        }

        /// <summary>
        /// Rerurn collection of the all answer
        /// </summary>
        /// <returns>Collection of answer from repository</returns>
        public IQueryable<Answer> GetAll()
        {
            return _db.Answers;
        }

        /// <summary>
        /// Update answer
        /// </summary>
        /// <param name="item">Answer object</param>
        public void Update(Answer item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
