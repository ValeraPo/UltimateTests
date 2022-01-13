using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Data;
using Data.Repositories;
using Data.Maps;

using NUnit.Framework;
using Tests.Logic;

namespace Tests.Data
{
    [TestFixture]
    public class UserTests
    {
        private UserRepo _user = new UserRepo();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _user.GetListEntity().Select(t =>t.ID_User);
            var actual = new ObservableCollection<long> {1, 2, 3, 4, 5, 6, 7, 8};
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(1,  "Gbl", 1, "asdjgklh@mail.ru", "admin")]
        [TestCase(2,  "Петров А.В.", 3, "qqqq@mail.ru", "petrov")] 
        [TestCase(3,  "Папов Г.А.", 2, "pppp@mail.ru", "papov")] 
        [TestCase(4,  "Писманик М.К.", 2, "rrrr@mail.ru", "pismanic")] 
        [TestCase(5,  "Гардеева М.А.", 2, "ffff@mail.ru", "gardeeva")] 
        public void GetEntityTest(long id_user,  string name, int id_role, string email, string login)
        {
            User user = _user.GetEntity(id_user);
            Assert.Equals(user.FullName, name);
            Assert.Equals(user.ID_Role, id_role);
            Assert.Equals(user.Email, email);
            Assert.Equals(user.Login, login);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _user.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            User item = new User();
            item.ID_Role = 0;
            Assert.Throws<System.InvalidOperationException>(() => _user.Create(item));
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            User item = new User();
            item.FullName = "12345678901234567890123456789012345678901234567890" +
                         "12345678901234567890123456789012345678901234567890" +
                         "12345678901234567890123456789012345678901234567890";
            Assert.Throws<System.InvalidOperationException>(() => _user.Create(item));
        }
        [Test]
        public void CreateNegativeTestThree()
        {
            User item = new User();
            item.Login = "1234567890123456789012345678901234567890123456789012345";
            Assert.Throws<System.InvalidOperationException>(() => _user.Create(item));
        }
        [Test]
        public void CreateNegativeTestFour()
        {
            User item = new User();
            item.Email = "1234567890123456789012345678901234567890123456789012345";
            Assert.Throws<System.InvalidOperationException>(() => _user.Create(item));
        }
        [Test]
        public void CreateNegativeTestFive()
        {
            User item = new User();
            item.Email = "ffff@mail.ru";
            Assert.Throws<System.InvalidOperationException>(() => _user.Create(item));
        }
        [Test]
        public void CreateNegativeTestSix()
        {
            User item = new User();
            item.Login = "papov";
            Assert.Throws<System.InvalidOperationException>(() => _user.Create(item));
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _user.Delete(0));
        }
    }
}