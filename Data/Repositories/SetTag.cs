using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class SetTag : IRepository<Maps.SetTag>
    {
        private Context db;
        private bool    _disposed;

        public SetTag() => db = Context.GetContext();


        public IEnumerable<Maps.SetTag> GetListEntity() => db.SetTags.Where(t => !t.IsDel);
        public Maps.SetTag GetEntity(long id) => db.SetTags.Find(id);
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