using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using MiniKartoteka.Modules.StatusBar.Abstract.ViewModels;
using MiniKartoteka.Modules.StatusBar.ViewModels;
using Microsoft.Practices.Unity;
using MiniKartoteka.Infrastructure;
using Prism.Regions;
using MiniKartoteka.Modules.StatusBar.Views;
using Prism.Modularity;

namespace MiniKartoteka.Modules.StatusBar
{
    public class StatusBarModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public StatusBarModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<IStatusBarViewViewModel, StatusBarViewViewModel>();
            IRegion statusBarRegion = _regionManager.Regions[RegionNames.STATUSBAR_REGION];

            statusBarRegion.Add(_container.Resolve<StatusBarView>());
        }
    }
}
