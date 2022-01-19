using System;
using System.Collections.ObjectModel;
using System.Linq;
using Data.Interfaces;
using Data.Maps;
using Logic.Configuration;
using NUnit.Framework;

namespace Tests.Data
{
    [TestFixture]
    public class UserTests
    {
        private readonly IRepository<User> _user = IocKernel.Get<IRepository<User>>();
        //
        //  
        [Test]
        public void GetListEntityTest()
        {
            var expected = _user.GetListEntity().Select(t => t.ID_User);
            var actual   = new ObservableCollection<long> { 1, 2, 3, 4, 5, 6, 7, 8, 13, 14, 19 };
            CollectionAssert.AreEqual(expected, actual);
        }
        //
        //
        [TestCase(1, "Gbl", 1, "asdjgklh@mail.ru", "admin")]
        [TestCase(2, "Петров А.В.", 3, "qqqq@mail.ru", "petrov")]
        [TestCase(3, "Папов Г.А.", 2, "pppp@mail.ru", "papov")]
        [TestCase(4, "Писманик М.К.", 2, "rrrr@mail.ru", "pismanic")]
        [TestCase(5, "Гардеева М.А.", 2, "ffff@mail.ru", "gardeeva")]
        public void GetEntityTest(long id_user, string name, int id_role, string email, string login)
        {
            var user = _user.GetEntity(id_user);
            Assert.AreEqual(user.FullName, name);
            Assert.AreEqual(user.ID_Role, id_role);
            Assert.AreEqual(user.Email, email);
            Assert.AreEqual(user.Login, login);
        }
        [Test]
        public void GetEntityNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _user.GetEntity(0));
        }
        [Test]
        public void CreateNegativeTestOne()
        {
            User item = new User();
            item.ID_Role = 0;
            _user.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _user.Save());
        }
        [Test]
        public void CreateNegativeTestTwo()
        {
            User item = new User
                        {
                            FullName = "12345678901234567890123456789012345678901234567890" +
                                       "12345678901234567890123456789012345678901234567890" +
                                       "12345678901234567890123456789012345678901234567890"
                        };
            _user.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _user.Save());
        }
        [Test]
        public void CreateNegativeTestThree()
        {
            User item = new User();
            item.Login = "1234567890123456789012345678901234567890123456789012345";
            _user.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _user.Save());
        }
        [Test]
        public void CreateNegativeTestFour()
        {
            User item = new User();
            item.Email = "1234567890123456789012345678901234567890123456789012345";
            _user.Create(item);
            Assert.Throws<System.Data.Entity.Validation.DbEntityValidationException>(() => _user.Save());
        }
        [Test]
        public void DeleteNegativeTest()
        {
            Assert.Throws<InvalidOperationException>(() => _user.Delete(0));
        }
    }
}