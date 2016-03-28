using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using System;
using MiniKartoteka.Modules.StatusBar;
using MiniKartoteka.Business.Services;
using MiniKartoteka.Modules.PatientsModule;
using MiniKartoteka.Modules.AppointmentsModule;
using MiniKartoteka.Data.DataBaseModels;

namespace MiniKartoteka
{
    public class Bootstrapper : UnityBootstrapper
    {
        #region Overrides
        protected override DependencyObject CreateShell()
        {
            NHibernateConfig.Initialize();

            Container.RegisterType<IShellViewModel, ShellViewModel>();
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            RegisterModule(typeof(ServicesModule));

            RegisterModule(typeof(PatientsModule));
            RegisterModule(typeof(AppointmentsModule));
            RegisterModule(typeof(StatusBarModule));
        }
        #endregion Overrides

        #region Methods
        private void RegisterModule(Type module)
        {
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = module.Name,
                ModuleType = module.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }
        #endregion Methods
    }
}
