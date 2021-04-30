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
    public class AnswerVariantsRepository : IRepository<AnswerVariant>
    {
        private readonly ApplicationContext _db;

        public AnswerVariantsRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(AnswerVariant item)
        {
            _db.AnswerVariants.Add(item);
        }

        public bool Delete(int id)
        {
            AnswerVariant answer = _db.AnswerVariants.Find(id);
            if (answer is object)
            {
                _db.AnswerVariants.Remove(answer);
                return true;
            }
            return false;
        }

        public IQueryable<AnswerVariant> Find(Func<AnswerVariant, bool> predicate)
        {
            return _db.AnswerVariants.Where(predicate).AsQueryable();
        }

        public AnswerVariant Get(int id)
        {
            return _db.AnswerVariants.Find(id);
        }

        public IQueryable<AnswerVariant> GetAll()
        {
            return _db.AnswerVariants;
        }

        public void Update(AnswerVariant item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
