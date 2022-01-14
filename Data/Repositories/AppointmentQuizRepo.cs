using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class AppointmentQuizRepo : IRepository<AppointmentQuizze>
    {
        private Context db;

        public AppointmentQuizRepo() => db = Context.GetContext();


        public IEnumerable<AppointmentQuizze> GetListEntity() => db.AppointmentQuizzes.Where(t => !t.IsDel);
        public AppointmentQuizze GetEntity(long id) => db.AppointmentQuizzes.Single(t=> !t.IsDel && t.ID_Appointment == id);
        public void Create(AppointmentQuizze item) => db.AppointmentQuizzes.Add(item);
        public void Update(AppointmentQuizze item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var tmp = db.AppointmentQuizzes.Find(id);
            if (tmp == null)
                return;
            tmp.IsDel = true;
            Save();
        }

    }
}