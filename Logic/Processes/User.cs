using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Data.Interfaces;
using Data.Maps;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class User : IUser
    {
        private IRepository<Data.Maps.User>  _users;
        private IRepository<Data.Maps.Quizze> _quizzes;
        private IRepository<Data.Maps.Group> _groups;
        private Data.Maps.User               _user;
        public User()
        {
            _users  = IocKernel.Get<IRepository<Data.Maps.User>>();
            _groups = IocKernel.Get<IRepository<Data.Maps.Group>>();
            _quizzes = IocKernel.Get<IRepository<Data.Maps.Quizze>>();
        }


        public UserDTO GetEntity(long id)
        {
            return new UserDTO(_users.GetEntity(id));
        }
        public ObservableCollection<UserDTO> GetListEntity()
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in _users.GetListEntity())
                res.Add(new UserDTO(user));

            return res;
        }

        #region Peoples
                //Выборка людей по типам учётных записей
                private ObservableCollection<UserDTO> GetListInteriorEmployers(IEnumerable<Data.Maps.User> collections)
                {
                    var res = new ObservableCollection<UserDTO>();
                    foreach (var user in collections)
                        res.Add(new UserDTO(user));
        
                    return res;
                }
                public ObservableCollection<UserDTO> GetListStud()
                {
                    return GetListInteriorEmployers(_users.GetListEntity().Where(t => t.ID_Role == 2));
                }
                public ObservableCollection<UserDTO> GetListTeacher()
                {
                    return GetListInteriorEmployers(_users.GetListEntity().Where(t => t.ID_Role == 3));
                }
                public ObservableCollection<UserDTO> GetListEmployers()
                {
                    return GetListInteriorEmployers(_users.GetListEntity().Where(t => t.ID_Role != 2));
                }

        #endregion
        

        // Проверка пароля при авторизации
        public UserDTO Authorization(string login, string password)
        {
            _user = Regex.IsMatch(login, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                ? _users.GetListEntity().Single(t => t.Email == login.ToLower())
                : _users.GetListEntity().Single(t => t.Login == login.ToLower());

            if (_user.HashPass != MD5Hash(password))
                throw new KeyNotFoundException("Пароль неверный");
            return new UserDTO(_user);
        }
        // Добавить нового пользователя
        public void AddNewUser(string fullName, string email, string login, string password, int id_role, long? group = null)
        {
            List<string> logins = _users.GetListEntity().Select(t => t.Login).ToList();
            List<string> emails = _users.GetListEntity().Select(t => t.Email).ToList();
            //Проверка существования логина
            if (logins.Contains(login.ToLower()))
                throw new ArgumentException("Логин уже существует");

            //Проверка существования email
            if (emails.Contains(email.ToLower()))
                throw new ArgumentException("E-mail уже существует");
            _users.Create(new Data.Maps.User
            {
                              FullName = fullName,
                              Email    = email,
                              Login    = login,
                              ID_Role  = id_role,
                              ID_Group = group,
                              HashPass = MD5Hash(password)
                          });
            SaveChange();
        }

        // Добавить группу преподу
        public void AddTeachingGroup(UserDTO teacher, GroupDTO group)
        {
            var userEntity = _users.GetEntity(teacher.Id);
            userEntity.TeachingGroups.Add(new TeachingGroup
            {
                                              ID_Group = group.Id,
                                              ID_User  = teacher.Id
                                          });
            SaveChange();
        }
        // Удаление группы преподу
        public void RemoveTeachingGroup(UserDTO teacher, GroupDTO group)
        {
            var userEntity = _users.GetEntity(teacher.Id);
            userEntity.TeachingGroups.Single(t => t.ID_Group == group.Id).IsDel = true;
            SaveChange();
        }
        //Добавление попытки
        public void AddAttempt(QuizzeDTO quiz, int score, TimeSpan transitTime)
        {
            _user.Attempts.Add(new Data.Maps.Attempt
            {
                                   DateTime    = DateTime.Now,
                                   ID_Quiz     = quiz.Id,
                                   User        = _user,
                                   Score       = score,
                                   TransitTime = transitTime
                               });
            SaveChange();
        }
        // Создание фидбека
        public void AddFeedback(QuizzeDTO quiz, string text)
        {
            var myQuiz = _quizzes.GetEntity(quiz.Id);
            myQuiz.Feedbacks.Add(new Data.Maps.Feedback
            {
                DateTime = DateTime.Now,
                ID_Quiz = quiz.Id,
                User = _user,
                Text = text
            });
            SaveChange();
        }
        //Выборка групп которые курирует преподаватель
        public ObservableCollection<GroupDTO> GetListGroupTeacher()
        {
            var res = new ObservableCollection<GroupDTO>();
            foreach (var group in _user.TeachingGroups.Select(t=>t.Group))
                res.Add(new GroupDTO(group));

            return res;
        }

        #region Attempt

                //Для выборок
                private ObservableCollection<AttemptDTO> GetAttemptCollection(IEnumerable<Data.Maps.Attempt> collection)
                {
                    var res = new ObservableCollection<AttemptDTO>();
                    foreach (var attempt in collection)
                        res.Add(new AttemptDTO(attempt));
        
                    return res;
                }
                //Выборка попыток по пользователю
                public ObservableCollection<AttemptDTO> GetListUserAttempt(UserDTO user)
                {
                    return GetAttemptCollection(_users.GetEntity(user.Id).Attempts);
                }
        
                //Выборка попыток по текущему пользователю
                public ObservableCollection<AttemptDTO> GetListCurrentUserAttempt()
                {
                    return GetAttemptCollection(_user.Attempts);
                }
                //Выборка попыток по текущему пользователю с датой
                public ObservableCollection<AttemptDTO> GetListCurrentUserAttempt(DateTime dateTime)
                {
                    return GetAttemptCollection(_user.Attempts.Where(t => t.DateTime >= dateTime));
                }
                //Выборка попыток по учителю
                public ObservableCollection<AttemptDTO> GetListTeacherAttempt()
                {
                    return GetAttemptCollection(_user.TeachingGroups
                                                     .Select(t => t.Group)
                                                     .SelectMany(t => t.Users)
                                                     .SelectMany(t => t.Attempts));
                }
                //Выборка попыток по учителю с датой
                public ObservableCollection<AttemptDTO> GetListTeacherAttempt(DateTime dateTime)
                {
                    return GetAttemptCollection(_user.TeachingGroups
                                                     .Select(t => t.Group)
                                                     .SelectMany(t => t.Users)
                                                     .SelectMany(t => t.Attempts)
                                                     .Where(t => t.DateTime >= dateTime));
                }

        #endregion


        // Возвращение назначенных тестов
        public ObservableCollection<AppointmentQuizzeDTO> GetAppointmentQuizzes()
        {
            var appointmentQuizzes = new ObservableCollection<AppointmentQuizzeDTO>();
            foreach (var appo in _user.AppointmentQuizzes
                                      .Where(t => t.FinishBefore >= DateTime.Now))
                appointmentQuizzes.Add(new AppointmentQuizzeDTO(appo));
            return appointmentQuizzes;
        }
        // Удаление пользователя
        public void RemoveUser(UserDTO user)
        {
            _users.Delete(user.Id);
        }
        public void RemoveUser(string email)
        {
            _users.Delete(_users.GetListEntity().Single(t=> t.Email == email).ID_User);
        }
        // Сохранить изменения
        public void SaveChange() => _users.Save();
        // Обновление модели (пересоздании зависимостей EF)
        public void Refresh() => _users.Refresh();

        //Сохранение изменения
        public void Update(UserDTO user)
        {
            var tmp = _users.GetEntity(user.Id);
            tmp.Email    = user.Email;
            tmp.FullName = user.FullName;
            tmp.ID_Role  = user.Type;
            tmp.ID_Group = _groups.GetListEntity()
                                  .Where(t => t.NameOfGroup == user.Group)
                                  .Select(t => t.ID_Group)
                                  .SingleOrDefault();
            if (tmp.ID_Group == 0)
                tmp.ID_Group = null;
            _users.Update(tmp);

            SaveChange();
        }
        public void Update(UserDTO user, string login, string password)
        {
            Update(user);
            var tmp = _users.GetEntity(user.Id);
            tmp.Login    = login;
            tmp.HashPass = MD5Hash(password);
            SaveChange();
        }

        // создание хеша пароля
        private static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
                strBuilder.Append(result[i].ToString("x2"));

            return strBuilder.ToString();
        }
    }
}