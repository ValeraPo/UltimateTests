using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Data.Maps;
using Logic.DTO;
using Logic.Interfaces;

namespace Logic.Processes
{
    public class User : IUser
    {
        private IRepository<Data.Maps.User>  _users;
        private IRepository<Data.Maps.Group> _groups;
        private Data.Maps.User               _user;
        public User(IRepository<Data.Maps.User> users, IRepository<Data.Maps.Group> group)
        {
            _users  = users;
            _groups = group;
        }


        public UserDTO GetEntity(long id)
        {
            return new UserDTO(_users.GetEntity(id));
        }
        public ObservableCollection<UserDTO> GetListEntity()
        {
            var res = new ObservableCollection<UserDTO>();
            foreach (var user in _users.GetListEntity()) { res.Add(new UserDTO(user)); }

            return res;
        }
        // Проверка пароля при авторизации
        public UserDTO Authorization(string login, string password)
        {
            _user = _users.GetListEntity().Single(t => t.Login == login.ToLower());
            if (_user.HashPass != Encryptor.MD5Hash(password))
                throw new KeyNotFoundException("Пароль неверный");
            return new UserDTO(_user);
        }
        // Добавить нового пользователя
        public void AddNewUser(string fullName, string email, string login, string password, int id_role, long? id_group = null)
        {
            List<string> logins = _users.GetListEntity().Select(t => t.Login).ToList(); // List<string>
            //Проверка существования логина
            if (logins.Contains(login.ToLower()))
                throw new ArgumentException("Логин уже существует");
            _users.Create(new Data.Maps.User()
                          {
                              FullName = fullName,
                              Email    = email,
                              Login    = login,
                              ID_Role  = id_role,
                              ID_Group = id_group,
                              HashPass = Encryptor.MD5Hash(password)
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
    }
}