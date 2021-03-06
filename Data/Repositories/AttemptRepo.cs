using System;
using System.Collections.Generic;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class AttemptRepo : AbstractRepo<Attempt>, IRepository<Attempt>
    {
        public IEnumerable<Attempt> GetListEntity()
        {
            if (!UpdateLintEntity) 
                return LintEntity;

            LintEntity       = Db.Attempts;
            UpdateLintEntity = false;
            return LintEntity;
        }

        public Attempt GetEntity(long id) => Db.Attempts.Find(id);

        public void Create(Attempt item)
        {
            Db.Attempts.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id) => throw new NotImplementedException();
    }
}