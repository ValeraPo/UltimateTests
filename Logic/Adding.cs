using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Data.Maps;

namespace Logic
{
    public static class Adding
    {
        // Добавить нового пользователя
        public static void AddNewUser(string fullName, string email, string login, string password, int id_role, long? id_group = null)
        {
            using IRepository<Data.Maps.User> users = new Data.Repositories.User();

            List<string> logins = users.GetListEntity().Select(t => t.Login).ToList(); // List<string>
            //Проверка существования логина
            if (logins.Contains(login.ToLower()))
                throw new ArgumentException("Логин уже существует");
            users.Create(new Data.Maps.User()
                         {
                             FullName = fullName,
                             Email    = email,
                             Login    = login,
                             ID_Role  = id_role,
                             ID_Group = id_group,
                             HashPass = Encryptor.MD5Hash(password)
                         });
            users.Save();
        }
        // Добавить группу преподу
        public static void AddTeachingGroup(Data.Maps.User teacher, Group group)
        {
            teacher.TeachingGroups.Add(new TeachingGroup()
                                       {
                                           Group = group,
                                           User  = teacher
                                       });
            Connecting.SaveChange();
        }
        //Добавить тег тесту
        public static void AddTagQuizze(long id_quizze, SetTag teg)
        {
            using IRepository<Data.Maps.Quizze> quizzes = new Data.Repositories.Quizze();
            var                                 quizze  = quizzes.GetEntity(id_quizze);
            quizze.QuizzesCategories.Add(new QuizzesCategory()
                                         {
                                             Quizze = quizze,
                                             SetTag = teg
                                         });
            quizzes.Save();
        }
        //Добавить тег группе
        public static void AddTagGroup(long id_group, SetTag teg)
        {
            using IRepository<Data.Maps.Group> groups = new Data.Repositories.Group();
            var                                group  = groups.GetEntity(id_group);
            group.GroupsCategories.Add(new GroupsCategory()
                                       {
                                           Group  = group,
                                           SetTag = teg
                                       });
            groups.Save();
        }
        // Добавить назначение по группе
        public static void AddAppointmentQuizze(long id_quizze, long id_group, DateTime finishBefore)
        {
            using IRepository<Data.Maps.Quizze> quizzes = new Data.Repositories.Quizze();
            using IRepository<Data.Maps.Group>  groups  = new Data.Repositories.Group();

            var quizze = quizzes.GetEntity(id_quizze);
            var group  = groups.GetEntity(id_group);

            foreach (var person in group.Users)
            {
                quizze.AppointmentQuizzes.Add(new Data.Maps.AppointmentQuizze()
                                              {
                                                  FinishBefore = finishBefore,
                                                  User         = person,
                                                  Quizze       = quizze
                                              });
            }

            quizzes.Save();
        }
        // Добавить назначение по человеку
        public static void AddAppointmentQuizzeUser(long id_quizze, long id_user, DateTime finishBefore)
        {
            using IRepository<Data.Maps.Quizze> quizzes  = new Data.Repositories.Quizze();
            using IRepository<Data.Maps.User>   students = new Data.Repositories.User();

            var quizze  = quizzes.GetEntity(id_quizze);
            var student = students.GetEntity(id_user);


            quizze.AppointmentQuizzes.Add(new Data.Maps.AppointmentQuizze()
                                          {
                                              FinishBefore = finishBefore,
                                              User         = student,
                                              Quizze       = quizze
                                          });

            quizzes.Save();
        }
    }
}