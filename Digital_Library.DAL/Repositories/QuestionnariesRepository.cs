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
    public class QuestionnariesRepository : IRepository<Questionnarie>
    {
        private readonly ApplicationContext _db;

        public QuestionnariesRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(Questionnarie item)
        {
            _db.Questionnaries.Add(item);
        }

        public bool Delete(int id)
        {
            Questionnarie questionnarie = _db.Questionnaries.Find(id);
            if (questionnarie is object)
            {
                _db.Questionnaries.Remove(questionnarie);
                return true;
            }
            return false;
        }

        public IQueryable<Questionnarie> Find(Func<Questionnarie, bool> predicate)
        {
            return _db.Questionnaries.Where(predicate).AsQueryable();
        }

        public Questionnarie Get(int id)
        {
            return _db.Questionnaries.Find(id);
        }

        public IQueryable<Questionnarie> GetAll()
        {
            return _db.Questionnaries;
        }

        public void Update(Questionnarie item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
