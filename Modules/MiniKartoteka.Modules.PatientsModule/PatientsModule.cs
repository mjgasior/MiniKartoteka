using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.PatientsModule.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Views;
using Prism.Regions;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;

namespace MiniKartoteka.Modules.PatientsModule
{
    public class PatientsModule : BaseModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public PatientsModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

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
            _regionManager.RegisterViewWithRegion(RegionNames.PATIENTSMODULE_CONTENT_REGION, typeof(AddPatientView));

            RegisterToolbarNavigation("Pacjenci");
        }

        public override void OnNavigationToModule()
        {
            _regionManager.RequestNavigate(RegionNames.MAINCONTENT_REGION, typeof(PatientsContentView).FullName);
        }
    }
}
