using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.PatientsModule.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Views;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;

namespace MiniKartoteka.Modules.PatientsModule
{
    public class PatientsModule : BaseModule
    {
        public override void RegisterTypes()
        {
            Container.RegisterType<IPatientsContentViewModel, PatientsContentViewModel>();
            Container.RegisterType<IAddPatientViewModel, AddPatientViewModel>();
            Container.RegisterType<IPatientsListViewModel, PatientsListViewModel>();

            Container.RegisterTypeForNavigation<PatientsContentView>();
            Container.RegisterTypeForNavigation<AddPatientView>();
            Container.RegisterTypeForNavigation<PatientsListView>();
        }

        public override void Init()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.PATIENTSMODULE_CONTENT_REGION, typeof(AddPatientView));
            RegisterToolbarNavigation("Pacjenci");
        }

        public override void OnNavigationToModule()
        {
            RegionManager.RequestNavigate(RegionNames.MAINCONTENT_REGION, nameof(PatientsContentView));
        }
    }
}
