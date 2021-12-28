using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class User : IRepository<Maps.User>
    {
        private Context db;
        private bool    _disposed;

        public User()
        {
            db = Context.GetContext();
        }
        
        
        public IEnumerable<Maps.User> GetListEntity()
        {
            return db.Users.Where(t=> !t.IsDel);
        }
        public Maps.User GetEntity(int id)
        {
            return db.Users.Find(id);
        }
        public void Create(Maps.User item)
        {
            db.Users.Add(item);
        }
        public void Update(Maps.User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var tmp = db.Users.Find(id);
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