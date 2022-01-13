using System;
using System.Collections.Generic;
using System.Data.Entity;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class AttemptRepo : IRepository<Maps.Attempt>
    {
        private Context db;

        public AttemptRepo() => db = Context.GetContext();


        public IEnumerable<Maps.Attempt> GetListEntity() => db.Attempts;
        public Maps.Attempt GetEntity(long id) => db.Attempts.Find(id);
        public void Create(Maps.Attempt item) => db.Attempts.Add(item);
        public void Update(Maps.Attempt item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id) => throw new NotImplementedException();
    }
}