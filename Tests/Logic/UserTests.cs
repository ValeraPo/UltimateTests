using System;
using System.Collections.ObjectModel;
using System.Linq;
using Logic.Configuration;
using Logic.DTO;
using Logic.Interfaces;
using NUnit.Framework;

namespace Tests.Logic
{
    [TestFixture]
    public class UserTests
    {
        private readonly IUser _user = IocKernel.Get<IUser>();

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
            return user switch
            {
                Users.Petrov   => new UserDTO(3, "Петров А.В.", "qqqq@mail.ru", null),
                Users.Papov    => new UserDTO(2, "Папов Г.А.", "pppp@mail.ru", "12929/1   "),
                Users.Pismanic => new UserDTO(2, "Писманик М.К.", "rrrr@mail.ru", "12929/1   "),
                Users.Holo     => new UserDTO(4, "Холо В.П.", "hhhh@mail.ru", null),
                Users.Putin    => new UserDTO(4, "Путин В.В.", "bgfd@mail.ru", null),
                _              => throw new ArgumentException()
            };
        }
        [TestCase(Users.Petrov, "petrov", "petrov")]
        [TestCase(Users.Papov, "papov", "papov")]
        [TestCase(Users.Pismanic, "pismanic", "pismanic")]
        [TestCase(Users.Holo, "holo", "holo")]
        [TestCase(Users.Putin, "putin", "putin")]
        public void AuthorizationTest(Users user, string login, string password)
        {
            var expectedUser = AuthorizationMockOutputData(user);
            var actualUser   = _user.Authorization(login, password);

            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Group, actualUser.Group);
            Assert.AreEqual(expectedUser.Type, actualUser.Type);
            Assert.AreEqual(expectedUser.FullName, actualUser.FullName);
        }
        [Test]
        public void AuthorizationNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _user.Authorization("login", "password"));
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
            return user switch
            {
                NewUsers.one   => new UserDTO(1, "1", "1", null),
                NewUsers.two   => new UserDTO(2, "2", "2", null),
                NewUsers.three => new UserDTO(3, "3", "3", null),
                NewUsers.four  => new UserDTO(4, "4", "4", null),
                _              => throw new ArgumentException()
            };
        }
        [TestCase(NewUsers.one, "1", "1", "1", "1", 1)]
        [TestCase(NewUsers.two, "2", "2", "2", "2", 2)]
        [TestCase(NewUsers.three, "3", "3", "3", "3", 3)]
        [TestCase(NewUsers.four, "4", "4", "4", "4", 4)]
        public void AddNewUserTest(NewUsers user, string fullName, string email, string login, string password,
            int id_role, long? id_group = null)
        {
            var expectedUser = AddNewUserMockOutputData(user);
            _user.AddNewUser(fullName, email, login, password, id_role, id_group);
            var actualUser = _user.Authorization(login, password);

            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Group, actualUser.Group);
            Assert.AreEqual(expectedUser.Type, actualUser.Type);
            Assert.AreEqual(expectedUser.FullName, actualUser.FullName);
        }

        [Test]
        public void AddNewUserNegativeTest()
        {
            Assert.Throws<ArgumentException>(() =>
                _user.AddNewUser("Владимир Путин", "putin@mail.ru", "putin", "putin", 1));
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
            _user.RemoveUser(myUser.Email);

            CollectionAssert.DoesNotContain(_user.GetListEntity().Select(t => t.Email).ToList(), myUser.Email);
        }

        //
        //Возврат назначенных тестов
        public enum Appointments
        {
            papov,
            pismanic,
            gardeeva
        }

        public static ObservableCollection<long> GetAppointmentQuizzesMockOutputData(Appointments appointment)
        {
            return appointment switch
            {
                Appointments.papov    => new ObservableCollection<long> { 25 },
                Appointments.pismanic => new ObservableCollection<long> { 26 },
                Appointments.gardeeva => new ObservableCollection<long> { 27 },
                _                     => throw new ArgumentException()
            };
        }
        [TestCase("papov", "papov", Appointments.papov)]
        [TestCase("pismanic", "pismanic", Appointments.pismanic)]
        [TestCase("gardeeva", "gardeeva", Appointments.gardeeva)]
        public void GetAppointmentQuizzesTest(string login, string password, Appointments appointment)
        {
            _user.Authorization(login, password);

            var expected = GetAppointmentQuizzesMockOutputData(appointment);
            var actual   = _user.GetAppointmentQuizzes().Select(t => t.Id);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}