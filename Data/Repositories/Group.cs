using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class Group : IRepository<Maps.Group>
    {
        private Context db;
        private bool    _disposed;

        public Group()
        {
            db = Context.GetContext();
        }
        
        
        public IEnumerable<Maps.Group> GetListEntity()
        {
            return db.Groups.Where(t => !t.IsDel);
        }
        public Maps.Group GetEntity(long id)
        {
            return db.Groups.Find(id);
        }
        public void Create(Maps.Group item)
        {
            db.Groups.Add(item);
        }
        public void Update(Maps.Group item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(long id)
        {
            var tmp = db.Groups.Find(id);
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