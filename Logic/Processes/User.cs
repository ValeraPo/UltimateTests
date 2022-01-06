using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        private IRepository<Data.Maps.Group> _groups;
        private Data.Maps.User               _user;
        public User()
        {
            _users  = IocKernel.Get<IRepository<Data.Maps.User>>();
            _groups = IocKernel.Get<IRepository<Data.Maps.Group>>();
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
        public ObservableCollection<UserDTO> GetListStud()
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in _users.GetListEntity().Where(t => t.ID_Role == 2))
                res.Add(new UserDTO(user));

            return res;
        }
        public ObservableCollection<UserDTO> GetListTeacher()
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in _users.GetListEntity().Where(t => t.ID_Role == 3))
                res.Add(new UserDTO(user));

            return res;
        }

        // Проверка пароля при авторизации
        public UserDTO Authorization(string login, string password)
        {
            try { _user = _users.GetListEntity().Single(t => t.Login == login.ToLower()); }
            catch (InvalidOperationException)
            {
                try { _user = _users.GetListEntity().Single(t => t.Email == login.ToLower()); }
                catch (InvalidOperationException) { throw new InvalidOperationException(); }
            }

            if (_user.HashPass != MD5Hash(password))
                throw new KeyNotFoundException("Пароль неверный");
            return new UserDTO(_user);
        }
        // Добавить нового пользователя
        public void AddNewUser(string fullName, string email, string login, string password, int id_role, long? id_group = null)
        {
            List<string> logins = _users.GetListEntity().Select(t => t.Login).ToList();
            List<string> emails = _users.GetListEntity().Select(t => t.Email).ToList();
            //Проверка существования логина
            if (logins.Contains(login.ToLower()))
                throw new ArgumentException("Логин уже существует");

            //Проверка существования email
            if (emails.Contains(email.ToLower()))
                throw new ArgumentException("E-mail уже существует");
            _users.Create(new Data.Maps.User()
                          {
                              FullName = fullName,
                              Email    = email,
                              Login    = login,
                              ID_Role  = id_role,
                              ID_Group = id_group,
                              HashPass = MD5Hash(password)
                          });
            _users.Save();
        }

        // Добавить группу преподу
        public void AddTeachingGroup(UserDTO teacher, GroupDTO group)
        {
            var userEntity = _users.GetEntity(teacher.Id);
            userEntity.TeachingGroups.Add(new TeachingGroup()
                                          {
                                              ID_Group = group.Id,
                                              ID_User  = teacher.Id
                                          });
            SaveChange();
        }

        // Возвращение назначенных тестов
        public ObservableCollection<QuizzeDTO> GetAppointmentQuizzes()
        {
            var appointmentQuizzes = new ObservableCollection<QuizzeDTO>();
            foreach (var quiz in _user.AppointmentQuizzes
                                      .Where(t => t.FinishBefore <= DateTime.Now)
                                      .Select(t => t.Quizze))
                appointmentQuizzes.Add(new QuizzeDTO(quiz, false));
            return appointmentQuizzes;
        }
        // Удаление пользователя
        public void RemoveUser(UserDTO user)
        {
            _users.Delete(user.Id);
        }
        // Сохранить изменения
        public void SaveChange() => _users.Save();
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