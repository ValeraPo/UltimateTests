using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class UserRepo : IRepository<Maps.User>
    {
        private Context db;

        public UserRepo() => db = Context.GetContext();


        public IEnumerable<Maps.User> GetListEntity() => db.Users.Where(t => !t.IsDel);
        public Maps.User GetEntity(long id) => db.Users.Single(t => !t.IsDel && t.ID_User == id);
        public void Create(Maps.User item) => db.Users.Add(item);
        public void Update(Maps.User item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
        public void Delete(long id)
        {
            var user = db.Users.Find(id);
            if (user == null)
                return;
            user.IsDel = true;
            foreach (var teach in user.TeachingGroups)
                teach.IsDel = true;
            Save();
        }
    }
}