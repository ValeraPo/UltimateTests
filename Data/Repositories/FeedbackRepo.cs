using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class FeedbackRepo : IRepository<Maps.Feedback>
    {
        private Context db;

        public FeedbackRepo() => db = Context.GetContext();


        public IEnumerable<Maps.Feedback> GetListEntity() => db.Feedbacks.Where(t => !t.IsDel);
        public Maps.Feedback GetEntity(long id) => db.Feedbacks.Single(t => !t.IsDel && t.ID_Feedback == id);
        public void Create(Maps.Feedback item) => db.Feedbacks.Add(item);
        public void Update(Maps.Feedback item) => db.Entry(item).State = EntityState.Modified;
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