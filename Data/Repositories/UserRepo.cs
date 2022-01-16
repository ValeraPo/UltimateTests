using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class UserRepo : AbstractRepo<User>, IRepository<User>
    {
        public IEnumerable<User> GetListEntity()
        {
            if (!UpdateLintEntity)
                return LintEntity;

            LintEntity       = db.Users.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public User GetEntity(long id) => db.Users.Single(t => !t.IsDel && t.ID_User == id);

        public void Create(User item)
        {
            db.Users.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var user = db.Users.Find(id);
            if (user == null)
                return;
            user.IsDel = true;
            foreach (var teach in user.TeachingGroups)
                teach.IsDel = true;
            Save();
            UpdateLintEntity = true;
        }
    }
}