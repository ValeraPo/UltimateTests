using System;
using System.Collections.Generic;
using System.Linq;
using Data.Maps;
using Logic;

namespace Data.Controllers
{
    public class HomeController
    {
        private static Context Db => Context.GetContext();
        public static IUser GetUser(string login)
        {
            var players = Db.Users.Where(t => t.Login == login && !t.IsDel).ToList();
            if (players.Count == 0)
                throw new ArgumentException("Данный пользователь не найден");
            return players[0].ID_Role switch
            {
                1 => new AdminBLL()
                     {
                         Login = players[0].Login,
                         Hash  = players[0].HashPass,
                         Name  = players[0].FullName,
                         ID    = players[0].ID_User
                     },
                2 => new StudentBLL()
                     {
                         Login = players[0].Login,
                         Hash  = players[0].HashPass,
                         Name  = players[0].FullName,
                         ID    = players[0].ID_User,
                         Group = players[0].Groups.NameOfGroup
                     },
                3 => new TeacherBLL()
                     {
                         Login = players[0].Login,
                         Hash  = players[0].HashPass,
                         Name  = players[0].FullName,
                         ID    = players[0].ID_User,
                         Groups = players[0].TeachingGroups.Select(t => t.Groups).Select(t=> t.NameOfGroup).ToList()
                     },
                4 => new MethodistBLL()
                     {
                         Login = players[0].Login,
                         Hash  = players[0].HashPass,
                         Name  = players[0].FullName,
                         ID    = players[0].ID_User,
                         Quizes = players[0].Quizzes.Select(t => t.ID_Quiz).ToList()
                     },
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}