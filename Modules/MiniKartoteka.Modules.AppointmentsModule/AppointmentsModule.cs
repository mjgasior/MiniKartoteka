using System;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using Prism.Modularity;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.AppointmentsModule.Views;

namespace MiniKartoteka.Modules.AppointmentsModule
{
    public class AppointmentsModule : BaseModule
    {
        public AppointmentsModule() 
        {

        }

        public override void Init()
        {
            RegisterToolbarNavigation("Wizyty");
        }

        public override void OnNavigationToModule()
        {
            RegionManager.RequestNavigate(RegionNames.MAINCONTENT_REGION, nameof(AppointmentsContentView));
        }

        public override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<AppointmentsContentView>();
        }
    }
}
