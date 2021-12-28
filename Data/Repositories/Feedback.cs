using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class Feedback : IRepository<Maps.Feedback>
    {
        private Context db;
        private bool    _disposed;

        public Feedback() => db = Context.GetContext();


        public IEnumerable<Maps.Feedback> GetListEntity() => db.Feedbacks.Where(t => !t.IsDel);
        public Maps.Feedback GetEntity(long id) => db.Feedbacks.Single(t => !t.IsDel && t.ID_Feedback == id);
        public void Create(Maps.Feedback item) => db.Feedbacks.Add(item);
        public void Update(Maps.Feedback item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var tmp = db.Feedbacks.Find(id);
            if (tmp == null)
                return;
            tmp.IsDel = true;
            Save();
        }


        protected virtual void Dispose(bool disposing)
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