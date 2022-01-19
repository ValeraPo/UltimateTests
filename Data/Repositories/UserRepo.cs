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

            LintEntity       = Db.Users.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public User GetEntity(long id) => Db.Users.Single(t => !t.IsDel && t.ID_User == id);

        public void Create(User item)
        {
            Db.Users.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var user = Db.Users.Find(id);
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