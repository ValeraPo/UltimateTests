using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class FeedbackRepo : IRepository<Feedback>
    {
        private Context db;

        public FeedbackRepo() => db = Context.GetContext();


        public IEnumerable<Feedback> GetListEntity() => db.Feedbacks.Where(t => !t.IsDel);
        public Feedback GetEntity(long id) => db.Feedbacks.Single(t => !t.IsDel && t.ID_Feedback == id);
        public void Create(Feedback item) => db.Feedbacks.Add(item);
        public void Update(Feedback item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var tmp = db.Feedbacks.Find(id);
            if (tmp == null)
                return;
            tmp.IsDel = true;
            Save();
        }
    }
}