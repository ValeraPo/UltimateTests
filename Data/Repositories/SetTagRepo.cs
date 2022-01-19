using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class SetTagRepo : AbstractRepo<SetTag>, IRepository<SetTag>
    {
        public IEnumerable<SetTag> GetListEntity()
        {
            if (!UpdateLintEntity) 
                return LintEntity;

            LintEntity       = Db.SetTags.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public SetTag GetEntity(long id) => Db.SetTags.Single(t => !t.IsDel && t.ID_TagSet == id);

        public void Create(SetTag item)
        {
            Db.SetTags.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var teg = Db.SetTags.Find(id);
            if (teg == null)
                return;
            teg.IsDel = true;
            foreach (var groups in teg.GroupsCategories)
                groups.IsDel = true;
            foreach (var quizzes in teg.QuizzesCategories)
                quizzes.IsDel = true;
            Save();
            UpdateLintEntity = true;
        }
    }
}