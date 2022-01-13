using System.Configuration;
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
            ConfigurationManager.AppSettings.Set("Connect",
                "data source=Stepa-PC;initial catalog=MyTestBD;User Id = Stepa195; Password = 195;MultipleActiveResultSets=True;App=EntityFramework");
            IocKernel.Initialize(new ProjectConfiguration());
        }
    }
}