using Logic.Configuration;
using Logic.Interfaces;
using Logic.Processes;
using NUnit.Framework;

namespace Tests
{
    public class UserTests
    {
        private IUser _user = IocKernel.Get<IUser>();

        [Test]
        public void AuthorizationNegativeTest()
        {
            Assert.Throws<System.InvalidOperationException>(() => _user.Authorization("login", "password"));
        }
        [Test]
        public void AddNewUserNegativeTest()
        {
            //TODO дописать существующие логин и емайл
            Assert.Throws<System.InvalidOperationException>(()
                => _user.AddNewUser("Владимир Путин", "bla-bla", "blabla", "blabla", 1));
        }
    }
}