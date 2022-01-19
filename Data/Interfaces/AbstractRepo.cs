using System.Collections.Generic;
using System.Data.Entity;
using Data.Controllers;

namespace Data.Interfaces
{
    public abstract class AbstractRepo<T>
        where T : class
    {
        internal Context        Db;
        internal bool           UpdateLintEntity = true;
        internal IEnumerable<T> LintEntity;
        protected AbstractRepo() => Db = Context.GetContext();

        public void Refresh()
        {
            Db.Dispose();
            Db = Context.GetContext();
        }

        public void Save()         => Db.SaveChanges();
        public void Update(T item) => Db.Entry(item).State = EntityState.Modified;
    }
}