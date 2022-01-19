using System.Configuration;
using System.Windows;
using Logic.Configuration;

namespace Visual
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Запуск одной копии приложения
        System.Threading.Mutex mutex;
        private void App_Startup(object sender, StartupEventArgs e)
        {
            bool   createdNew;
            string mutName = "Приложение";
            mutex = new System.Threading.Mutex(true, mutName, out createdNew);
            if (!createdNew)
            {
                Shutdown();
            }
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigurationManager.AppSettings.Set("Connect",
                                                 "data source=25.42.67.177;initial catalog=MyTestBD;User Id = Stepa195; Password = 195;MultipleActiveResultSets=True;App=EntityFramework");
            IocKernel.Initialize(new ProjectConfiguration());
            base.OnStartup(e);
        }
    }
}