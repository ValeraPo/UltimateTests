using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class AppointmentQuizze : IRepository<Maps.AppointmentQuizze>
    {
        private Context db;
        private bool    _disposed;

        public AppointmentQuizze() => db = Context.GetContext();


        public IEnumerable<Maps.AppointmentQuizze> GetListEntity() => db.AppointmentQuizzes.Where(t => !t.IsDel);
        public Maps.AppointmentQuizze GetEntity(long id) => db.AppointmentQuizzes.Find(id);
        public void Create(Maps.AppointmentQuizze item) => db.AppointmentQuizzes.Add(item);
        public void Update(Maps.AppointmentQuizze item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var tmp = db.AppointmentQuizzes.Find(id);
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