using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Data.Maps;
using Data.Repositories;
using Data.Interfaces;
using Feedback = Data.Maps.Feedback;
using Group = Data.Maps.Group;
using Quizze = Data.Maps.Quizze;
using SetTag = Data.Maps.SetTag;


namespace Logic
{
    public static class Connecting
    {
        private static Data.Maps.User user;

        // Проверка пароля при авторизации
        public static User Authorization(string login, string password)
        {
            using IRepository<Data.Maps.User> users = new Data.Repositories.User();
            user = users.GetListEntity().Single(t => t.Login == login.ToLower());
            if (user.HashPass != Encryptor.MD5Hash(password))
                throw new KeyNotFoundException("Пароль неверный");
            return new User()
                   {
                       FullName = user.FullName,
                       Email    = user.Email,
                       Type     = user.ID_Role,
                       Group    = user.Group?.NameOfGroup
                   };
        }

        // Создание фидбека
        public static void AddFeedback(long id_quizze, string text)
        {
            using IRepository<Data.Maps.Quizze> quizzes = new Data.Repositories.Quizze();

            var quizze = quizzes.GetEntity(id_quizze);
            quizze.Feedbacks.Add(new Feedback()
                                 {
                                     DateTime = DateTime.Now,
                                     Quizze   = quizze,
                                     User     = user,
                                     Text     = text
                                 });
            quizzes.Save();
        }
        // Возвращение назначенных тестов
        public static IEnumerable<Quizze> GetAppointmentQuizzes()
        {
            return user.AppointmentQuizzes
                       .Where(t => t.FinishBefore <= DateTime.Now)
                       .Select(t => t.Quizze);
        }
        // Сохранить изменения
        public static void SaveChange()
        {
            new Data.Repositories.User().Save();
        }
        // Показать фидбеки к тестам методиста
        public static IEnumerable<Feedback> GetFeedback()
        {
            return user.Quizzes.SelectMany(quiz => quiz.Feedbacks).ToList();
        }
    }
}