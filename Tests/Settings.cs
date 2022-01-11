using Logic.Configuration;
using NUnit.Framework;

namespace Tests
{

    [SetUpFixture]
    public class Settings
    {
        [OneTimeSetUp]
        public void Init()
        {
            IocKernel.Initialize(new ProjectConfiguration());
        }
    }
}