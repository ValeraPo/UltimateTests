using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class QuizzeRepo : AbstractRepo<Quizze>, IRepository<Quizze>
    {
        public IEnumerable<Quizze> GetListEntity()
        {
            if (!UpdateLintEntity) return LintEntity;
            
            LintEntity = db.Quizzes.Where(t => !t.IsDel);
            UpdateLintEntity = false;
            return LintEntity;
        }

        public Quizze GetEntity(long id) => db.Quizzes.Single(t => !t.IsDel && t.ID_Quiz == id);
        
        public void Create(Quizze item)
        {
            db.Quizzes.Add(item);
            UpdateLintEntity = true;
        }

        public void Delete(long id)
        {
            var quizze = db.Quizzes.Find(id);
            if (quizze == null)
                return;
            quizze.IsDel = true;
            foreach (var appo in quizze.AppointmentQuizzes)
                appo.IsDel = true;

            foreach (var question in quizze.Questions)
            {
                foreach (var answer in question.Answers)
                    answer.IsDel = true;
                question.IsDel = true;
            }
            Save();
            UpdateLintEntity = true;
        }
    }
}