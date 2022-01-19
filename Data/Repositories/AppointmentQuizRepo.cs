using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class AppointmentQuizRepo : AbstractRepo<AppointmentQuizze>, IRepository<AppointmentQuizze>
    {
        public IEnumerable<AppointmentQuizze> GetListEntity()
        {
            if (!UpdateLintEntity)
                return LintEntity;

            LintEntity       = Db.AppointmentQuizzes.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public AppointmentQuizze GetEntity(long id) =>
            Db.AppointmentQuizzes.Single(t => !t.IsDel && t.ID_Appointment == id);

        public void Create(AppointmentQuizze item)
        {
            Db.AppointmentQuizzes.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var tmp = Db.AppointmentQuizzes.Find(id);
            if (tmp == null)
                return;
            tmp.IsDel = true;
            Save();
            UpdateLintEntity = true;
        }
    }
}