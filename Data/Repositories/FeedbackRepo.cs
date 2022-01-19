using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class FeedbackRepo : AbstractRepo<Feedback>, IRepository<Feedback>
    {
        public IEnumerable<Feedback> GetListEntity()
        {
            if (!UpdateLintEntity) 
                return LintEntity;

            LintEntity       = Db.Feedbacks.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public Feedback GetEntity(long id) => Db.Feedbacks.Single(t => !t.IsDel && t.ID_Feedback == id);

        public void Create(Feedback item)
        {
            Db.Feedbacks.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var tmp = Db.Feedbacks.Find(id);
            if (tmp == null)
                return;
            tmp.IsDel = true;
            Save();
            UpdateLintEntity = true;
        }
    }
}