using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using Logic.Processes;
using NUnit.Framework;

namespace Tests
{    
    [TestFixture]
    public class UserTests
    {
        private IUser _user = IocKernel.Get<IUser>();
        //
        //Авторизация
        public enum Users
        {
            Petrov,
            Papov,
            Pismanic,
            Holo,
            Putin
        }
        public static UserDTO AuthorizationMockOutputData(Users user)
        {
            switch (user)
            {
                case Users.Petrov: 
                {
                    return new UserDTO( 3, "Петров А.В.", "qqqq@mail.ru", null);
                }
                case Users.Papov: 
                {
                    return new UserDTO( 2, "Папов Г.А.", "pppp@mail.ru", "12929/1");
                }
                case Users.Pismanic: 
                {
                    return new UserDTO( 2, "Писманик М.К.", "rrrr@mail.ru", "12929/1");
                }
                case Users.Holo: 
                {
                    return new UserDTO( 4, "Холо В.П.", "hhhh@mail.ru", null);
                }
                case Users.Putin: 
                {
                    return new UserDTO( 4, "Путин В.В.", "bgfd@mail.ru", null);
                }
                default: throw new ArgumentException();
            }
        }
        [TestCase(Users.Petrov, "petrov", "petrov")]
        [TestCase(Users.Papov, "papov", "papov")]
        [TestCase(Users.Pismanic, "pismanic", "pismanic")]
        [TestCase(Users.Holo, "holo", "holo")]
        [TestCase(Users.Putin, "putin", "putin")]
        public void AuthorizationTest(Users user, string login, string password)
        {
            var expectedUser = AuthorizationMockOutputData(user);
            var actualUser = _user.Authorization(login, password);

            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Group, actualUser.Group);
            Assert.AreEqual(expectedUser.Type, actualUser.Type);
            Assert.AreEqual(expectedUser.FullName, actualUser.FullName);

        }
        [Test]
        public void AuthorizationNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _user.Authorization("login", "password"));
        }
        //
        // Добавление пользователя 
        public enum NewUsers
        {
            one,
            two,
            three,
            four
        }
        public static UserDTO AddNewUserMockOutputData(NewUsers user)
        {
            switch (user)
            {
                case NewUsers.one: 
                {
                    return new UserDTO(9, 1, "1", "1", null);
                }
                case NewUsers.two: 
                {
                    return new UserDTO(10, 2, "2", "2", "12929/1");
                }
                case NewUsers.three: 
                {
                    return new UserDTO(11, 3, "3", "3", null);
                }
                case NewUsers.four: 
                {
                    return new UserDTO(12, 4, "4", "4", null);
                }
                
                default: throw new ArgumentException();
            }
        }
        [TestCase(NewUsers.one, "1", "1", "1", "1", 1)]
        [TestCase(NewUsers.two, "2", "2", "2", "2", 2, 1)]
        [TestCase(NewUsers.three, "3", "3", "3", "3", 3)]
        [TestCase(NewUsers.four, "4", "4", "4", "4", 4)]
        public void AddNewUserTest(NewUsers user, string fullName, string email, string login, string password, int id_role, long? id_group = null)
        {
            var expectedUser = AddNewUserMockOutputData(user);
            var actualUser = _user.Authorization(login, password);

            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Group, actualUser.Group);
            Assert.AreEqual(expectedUser.Type, actualUser.Type);
            Assert.AreEqual(expectedUser.FullName, actualUser.FullName);
        }
        
        [Test]
        public void AddNewUserNegativeTest()
        {
            Assert.Throws<ArgumentException>(() => _user.AddNewUser("Владимир Путин", "putin@mail.ru", "putin", "putin", 1));
        }
        //
        // Удаление пользователя
        [TestCase(NewUsers.one)]
        [TestCase(NewUsers.two)]
        [TestCase(NewUsers.three)]
        [TestCase(NewUsers.four)]
        public void RemoveUserTest(NewUsers user)
        {
            var myUser = AddNewUserMockOutputData(user);
            _user.RemoveUser(myUser);

            CollectionAssert.DoesNotContain(_user.GetListEntity().Select(t => t.Email).ToList(), myUser.Email);
        }
        //
        // Добавить группу преподу
        // TODO сделать после того как появится удаление группы у препода
        //
        //Возврат назначенных тестов
        public enum Appointments
        {
            papov, 
            pismanic,
            gardeeva
        }
        public static ObservableCollection<QuizzeDTO> GetAppointmentQuizzesMockOutputData(Appointments appointment)
        {
            switch (appointment)
            {
                case Appointments.papov:
                {
                    ObservableCollection<QuizzeDTO> mylist = new ObservableCollection<QuizzeDTO>();
                    //add
                    return mylist;
                }
                case Appointments.pismanic: 
                {
                    ObservableCollection<QuizzeDTO> mylist = new ObservableCollection<QuizzeDTO>();
                    //add
                    return mylist;
                }
                case Appointments.gardeeva: 
                {
                    ObservableCollection<QuizzeDTO> mylist = new ObservableCollection<QuizzeDTO>();
                    //add
                    return mylist;
                }
                
                default: throw new ArgumentException();
            }
        }
        [TestCase("papov", "papov", Appointments.papov)]
        [TestCase("pismanic", "pismanic", Appointments.pismanic)]
        [TestCase("gardeeva", "gardeeva", Appointments.gardeeva)]
        public void GetAppointmentQuizzesTest(string login, string password, Appointments appointment)
        {
            _user.Authorization(login, password);

            ObservableCollection<QuizzeDTO> expected = GetAppointmentQuizzesMockOutputData(appointment);
            ObservableCollection<QuizzeDTO> actual = _user.GetAppointmentQuizzes();
            CollectionAssert.AreEqual(expected, actual);

        }
        
    }
}