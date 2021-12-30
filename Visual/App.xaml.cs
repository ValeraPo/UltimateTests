using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using Visual.Configuration;

namespace Visual
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NinjectModule registrations = new ProjectConfiguration();
            var           kernel        = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            base.OnStartup(e);
        }
    }
}