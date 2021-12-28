using System;
using System.Collections.Generic;
using System.Data.Entity;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class Attempt : IRepository<Maps.Attempt>
    {
        private Context db;
        private bool    _disposed;

        public Attempt()
        {
            db = Context.GetContext();
        }
        
        
        public IEnumerable<Maps.Attempt> GetListEntity()
        {
            return db.Attempts;
        }
        public Maps.Attempt GetEntity(long id)
        {
            return db.Attempts.Find(id);
        }
        public void Create(Maps.Attempt item)
        {
            db.Attempts.Add(item);
        }
        public void Update(Maps.Attempt item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(long id)
        {
            throw new NotImplementedException();
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