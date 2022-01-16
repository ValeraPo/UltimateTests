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
            if (!UpdateLintEntity) return LintEntity;
            
            LintEntity = db.Feedbacks.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public Feedback GetEntity(long id) => db.Feedbacks.Single(t => !t.IsDel && t.ID_Feedback == id);
        
        public void Create(Feedback item)
        {
            db.Feedbacks.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var tmp = db.Feedbacks.Find(id);
            if (tmp == null)
                return;
            tmp.IsDel = true;
            Save();
            UpdateLintEntity = true;
        }
    }
}