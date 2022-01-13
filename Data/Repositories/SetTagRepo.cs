using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class SetTagRepo : IRepository<Maps.SetTag>
    {
        private Context db;

        public SetTagRepo() => db = Context.GetContext();


        public IEnumerable<Maps.SetTag> GetListEntity() => db.SetTags.Where(t => !t.IsDel);
        public Maps.SetTag GetEntity(long id) => db.SetTags.Single(t => !t.IsDel && t.ID_TagSet == id);
        public void Create(Maps.SetTag item) => db.SetTags.Add(item);
        public void Update(Maps.SetTag item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var teg = db.SetTags.Find(id);
            if (teg == null)
                return;
            teg.IsDel = true;
            foreach (var groups in teg.GroupsCategories)
                groups.IsDel = true;
            foreach (var quizzes in teg.QuizzesCategories)
                quizzes.IsDel = true;
            Save();
        }
    }
}