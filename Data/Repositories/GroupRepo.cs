using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class GroupRepo : AbstractRepo<Group>, IRepository<Group>
    {
        public IEnumerable<Group> GetListEntity()
        {
            if (!UpdateLintEntity) return LintEntity;
            
            LintEntity = db.Groups.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public Group GetEntity(long id) => db.Groups.Single(t => !t.IsDel && t.ID_Group == id);
        
        public void Create(Group item)
        {
            db.Groups.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var group = db.Groups.Find(id);
            if (group == null)
                return;
            group.IsDel = true;
            foreach (var teach in group.TeachingGroups)
                teach.IsDel = true;
            foreach (var students in group.Users)
                students.Group = null;
            foreach (var tags in group.GroupsCategories)
                tags.IsDel = true;
            Save();
            UpdateLintEntity = true;
        }
    }
}