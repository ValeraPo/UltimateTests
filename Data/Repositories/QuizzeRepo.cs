using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;
using Data.Maps;

namespace Data.Repositories
{
    public class QuizzeRepo : IRepository<Quizze>
    {
        private Context db;

        public QuizzeRepo() => db = Context.GetContext();


        public IEnumerable<Quizze> GetListEntity() => db.Quizzes.Where(t => !t.IsDel);
        public Quizze GetEntity(long id) => db.Quizzes.Single(t => !t.IsDel && t.ID_Quiz == id);
        public void Create(Quizze item) => db.Quizzes.Add(item);
        public void Update(Quizze item) => db.Entry(item).State = EntityState.Modified;
        public void Save() => db.SaveChanges();
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
        }
    }
}