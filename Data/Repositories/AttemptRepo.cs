using System;
using System.Collections.Generic;
using System.Data.Entity;
using Data.Controllers;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class AttemptRepo : IRepository<Attempt>
    {
        private Context db;

        public AttemptRepo() => db = Context.GetContext();


        public IEnumerable<Attempt> GetListEntity() => db.Attempts;
        public Attempt GetEntity(long id) => db.Attempts.Find(id);
        public void Create(Attempt item) => db.Attempts.Add(item);
        public void Update(Attempt item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id) => throw new NotImplementedException();
    }
}