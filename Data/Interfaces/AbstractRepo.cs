using System.Collections.Generic;
using System.Data.Entity;
using Data.Controllers;

namespace Data.Interfaces
{
    public abstract class AbstractRepo<T>
        where T: class
    {
        internal Context db;
        internal bool UpdateLintEntity = true;
        internal IEnumerable<T> LintEntity;

        protected AbstractRepo() => db = Context.GetContext();

        public void Refresh()
        {
            db.Dispose();
            db = Context.GetContext();
        }
        public void Save() => db.SaveChanges();
        public void Update(T item) => db.Entry(item).State = EntityState.Modified;
    }
}