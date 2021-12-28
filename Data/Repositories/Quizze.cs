using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class Quizze : IRepository<Maps.Quizze>
    {
        private Context db;
        private bool    _disposed;

        public Quizze()
        {
            db = Context.GetContext();
        }
        
        
        public IEnumerable<Maps.Quizze> GetListEntity()
        {
            return db.Quizzes.Where(t => !t.IsDel);
        }
        public Maps.Quizze GetEntity(int id)
        {
            return db.Quizzes.Find(id);
        }
        public void Create(Maps.Quizze item)
        {
            db.Quizzes.Add(item);
        }
        public void Update(Maps.Quizze item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var tmp = db.Quizzes.Find(id);
            if (tmp != null)
                tmp.IsDel = true;
        }
        public void Save()
        {
            db.SaveChanges();
        }


        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                db.Dispose();

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}