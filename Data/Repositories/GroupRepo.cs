using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class GroupRepo : IRepository<Maps.Group>
    {
        private Context db;
        
        public GroupRepo() => db = Context.GetContext();


        public IEnumerable<Maps.Group> GetListEntity() => db.Groups.Where(t => !t.IsDel);
        public Maps.Group GetEntity(long id) => db.Groups.Single(t => !t.IsDel && t.ID_Group == id);
        public void Create(Maps.Group item) => db.Groups.Add(item);
        public void Update(Maps.Group item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
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
        }
    }
}