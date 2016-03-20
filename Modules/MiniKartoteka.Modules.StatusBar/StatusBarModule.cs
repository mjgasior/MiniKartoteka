using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using MiniKartoteka.Modules.StatusBar.Abstract.ViewModels;
using MiniKartoteka.Modules.StatusBar.ViewModels;
using Microsoft.Practices.Unity;
using MiniKartoteka.Infrastructure;
using Prism.Regions;
using MiniKartoteka.Modules.StatusBar.Views;

namespace MiniKartoteka.Modules.StatusBar
{
    public class StatusBarModule : BaseModule
    {
        public override void Initialize()
        {
            Container.RegisterType<IStatusBarViewViewModel, StatusBarViewViewModel>();
            IRegion statusBarRegion = RegionManager.Regions[RegionNames.STATUSBAR_REGION];

            statusBarRegion.Add(Container.Resolve<StatusBarView>());
        }
    }
}
