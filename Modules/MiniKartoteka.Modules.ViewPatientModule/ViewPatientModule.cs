using MiniKartoteka.Infrastructure;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using MiniKartoteka.Modules.ViewPatientModule.ViewModels;
using MiniKartoteka.Modules.ViewPatientModule.Views;
using MiniKartoteka.Presentation.Controls;
using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels;

namespace MiniKartoteka.Modules.ViewPatientModule
{
    public class ViewPatientModule : BaseModule
    {
        public ViewPatientModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager) { }

        public override void RegisterTypes()
        {
            Container.RegisterType<IContentViewViewModel, ContentViewViewModel>();
            Container.RegisterType<IPersonDetailsViewViewModel, PersonDetailsViewViewModel>();

            Container.RegisterType<object, ContentView>(typeof(ContentView).FullName);
        }

        public override void Initialize()
        {
            IRegion toolbarRegion = RegionManager.Regions[RegionNames.TOOLBAR_REGION];
            toolbarRegion.Add(new ToolbarMenuView(new ViewPatientMenuViewModel(RegionManager, Container)));

            IRegion navigationRegion = RegionManager.Regions[RegionNames.NAVIGATION_REGION];
            navigationRegion.Add(new ViewPatientModuleButton());

            RegionManager.RegisterViewWithRegion(RegionNames.CONTENT_REGION, typeof(ContentView));
            RegionManager.RegisterViewWithRegion(RegionNames.VIEWPATIENT_PERSONDETAILS_REGION, typeof(PersonDetailsView));
        }
    }
}
