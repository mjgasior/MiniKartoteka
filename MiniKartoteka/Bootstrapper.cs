﻿using System.Windows;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System.Windows.Controls;
using MiniKartoteka.Infrastructure;
using Prism.Modularity;
using MiniKartoteka.Modules.AddNewPatientModule;
using System;
using MiniKartoteka.Modules.StatusBar;

namespace MiniKartoteka
{
    public class Bootstrapper : UnityBootstrapper
    {
        #region Overrides
        protected override DependencyObject CreateShell()
        {
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
            RegisterModule(typeof(AddNewPatientModule));
            RegisterModule(typeof(StatusBarModule));
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            mappings.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mappings;
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
