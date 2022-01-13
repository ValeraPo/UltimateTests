using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Controllers;
using Data.Interfaces;

namespace Data.Repositories
{
    public class QuizzeRepo : IRepository<Maps.Quizze>
    {
        private Context db;

        public QuizzeRepo() => db = Context.GetContext();


        public IEnumerable<Maps.Quizze> GetListEntity() => db.Quizzes.Where(t => !t.IsDel);
        public Maps.Quizze GetEntity(long id) => db.Quizzes.Single(t => !t.IsDel && t.ID_Quiz == id);
        public void Create(Maps.Quizze item) => db.Quizzes.Add(item);
        public void Update(Maps.Quizze item) => db.Entry(item).State = EntityState.Modified;
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