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

        public AppointmentQuizze()
        {
            db = Context.GetContext();
        }
        
        
        public IEnumerable<Maps.AppointmentQuizze> GetListEntity()
        {
            return db.AppointmentQuizzes.Where(t => !t.IsDel);
        }
        public Maps.AppointmentQuizze GetEntity(int id)
        {
            return db.AppointmentQuizzes.Find(id);
        }
        public void Create(Maps.AppointmentQuizze item)
        {
            db.AppointmentQuizzes.Add(item);
        }
        public void Update(Maps.AppointmentQuizze item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            var tmp = db.AppointmentQuizzes.Find(id);
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