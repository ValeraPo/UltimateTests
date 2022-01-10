using Logic.Configuration;
using Logic.Interfaces;
using Logic.Processes;
using NUnit.Framework;

namespace Tests
{
    public class UserTests
    {
        //private IUser _user = IocKernel.Get<IUser>();

        [Test]
        public void AuthorizationNegativeTest()
        {
            IocKernel.Initialize(new ProjectConfiguration());
            Assert.Throws<System.InvalidOperationException>(() => IocKernel.Get<IUser>().Authorization("login", "password"));
        }
        [Test]
        public void AddNewUserNegativeTest()
        {
            IocKernel.Initialize(new ProjectConfiguration());
            //TODO дописать существующие логин и емайл
            Assert.Throws<System.InvalidOperationException>(()
                => IocKernel.Get<IUser>().AddNewUser("Владимир Путин", "bla-bla", "blabla", "blabla", 1));
        }
    }
}