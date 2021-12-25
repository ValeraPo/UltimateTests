using System;
using System.Collections.Generic;
using System.Linq;
using Data.Maps;
//using Logic;

namespace Data.Controllers
{
    public class HomeController
    {
        private static Context Db => Context.GetContext();
        /*public static IUser GetUser(string login)
        {
            var players = Db.Users.Single(t => t.Login == login && !t.IsDel);
            
            return players.ID_Role switch
            {
                1 => new AdminBLL()
                     {
                         Login = players.Login,
                         Hash  = players.HashPass,
                         Name  = players.FullName,
                         ID    = players.ID_User
                     },
                2 => new StudentBLL()
                     {
                         Login = players.Login,
                         Hash  = players.HashPass,
                         Name  = players.FullName,
                         ID    = players.ID_User,
                         Group = players.Groups.NameOfGroup
                     },
                3 => new TeacherBLL()
                     {
                         Login = players.Login,
                         Hash  = players.HashPass,
                         Name  = players.FullName,
                         ID    = players.ID_User,
                         Groups = players.TeachingGroups
                                         .Select(t => t.Groups)
                                         .Select(t=> t.NameOfGroup)
                                         .ToList()
                     },
                4 => new MethodistBLL()
                     {
                         Login = players.Login,
                         Hash  = players.HashPass,
                         Name  = players.FullName,
                         ID    = players.ID_User,
                         Quizes = players.Quizzes
                                         .Select(t => t.ID_Quiz)
                                         .ToList()
                     },
                _ => throw new ArgumentOutOfRangeException()
            };
        }*/

        public static List<string> LoginActive => Db.Users.Where(t => !t.IsDel).Select(t => t.Login).ToList();

        public static List<long> GetIdQuizzes(string teg)
        {
           return Db.SetTags
                    .Where(t => !t.IsDel && t.Text == teg)
                    .Select(t => t.QuizzesCategories)
                    .Single()
                    .Select(t => t.ID_Quiz).ToList();
        }
        public static List<long> GetIdQuizzes(long idUser)
        {
            return Db.Users
                     .Where(t => !t.IsDel && t.ID_User == idUser)
                     .Select(t => t.AppointmentQuizzes)
                     .Single()
                     .Select(t => t.ID_Quiz)
                     .ToList();
        }

        public static List<(string, long)> GetFeedback(long idUser)
        {
            var feedback = Db.Users
                             .Single(t => !t.IsDel && t.ID_User == idUser)
                             .Quizzes
                             .Select(t=>t.Feedbacks);
            return (from t in feedback from m in t select (m.Text, m.ID_Quiz)).ToList();
        }

        /*public static QuizeBLL GetQuiz(long idQuiz)
        {
            var quizzes = Db.Quizzes
                            .Single(t => !t.IsDel && t.ID_Quiz == idQuiz);
            var questions = (
                from quest in quizzes.Questions 
                let answers = quest.Answers
                                   .Select(answer => (answer.Text, answer.IsCorrect))
                                   .ToList() 
                select new QuizeBLL.Question(quest.Text, answers))
                .ToList();
            return new QuizeBLL(questions, quizzes.MaxPoints);
        }*/
    }
}