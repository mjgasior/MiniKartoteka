using System;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;

namespace MiniKartoteka.Infrastructure.Concrete.Mvvm
{
    public abstract class BaseModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public abstract void RegisterTypes();
        public abstract void Init();
        public abstract void OnNavigationToModule();

        public void Initialize()
        {
            RegisterTypes();
            Init();
        }

        protected void RegisterToolbarNavigation(string name)
        {
            IRegion region = RegionManager.Regions[RegionNames.TOOLBAR_REGION];
            region.Add(new
            {
                Title = name,
                NavigateCommand = new DelegateCommand(OnNavigationToModule)
            });
        }
    }
}
