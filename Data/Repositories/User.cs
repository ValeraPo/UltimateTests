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

        public User() => db = Context.GetContext();


        public IEnumerable<Maps.User> GetListEntity() => db.Users.Where(t => !t.IsDel);
        public Maps.User GetEntity(long id) => db.Users.Find(id);
        public void Create(Maps.User item) => db.Users.Add(item);
        public void Update(Maps.User item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var user = db.Users.Find(id);
            if (user == null)
                return;
            user.IsDel = true;
            foreach (var teach in user.TeachingGroups)
                teach.IsDel = true;
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