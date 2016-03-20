using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System.Windows.Controls;
using MiniKartoteka.Infrastructure;
using Prism.Modularity;
using MiniKartoteka.Modules.AddNewPatientModule;
using System;

namespace MiniKartoteka
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    ModuleCatalog catalog = new ModuleCatalog();
        //    catalog.AddModule(typeof(AddNewPatientModule));
        //    return catalog;       
        //}

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @".\Modules" };
        //}

        protected override void ConfigureModuleCatalog()
        {
            Type module = typeof(AddNewPatientModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = module.Name,
                ModuleType = module.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
        }
    }
}
