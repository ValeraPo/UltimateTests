using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private Context db;

        public UserRepo() => db = Context.GetContext();


        public IEnumerable<User> GetListEntity() => db.Users.Where(t => !t.IsDel);
        public User GetEntity(long id) => db.Users.Single(t => !t.IsDel && t.ID_User == id);
        public void Create(User item) => db.Users.Add(item);
        public void Update(User item) => db.Entry(item).State = EntityState.Modified;
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