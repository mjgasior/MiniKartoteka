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
        public override void Initialize()
        {
            Container.RegisterType<IContentViewViewModel, ContentViewViewModel>();
            Container.RegisterType<IPersonDetailsViewViewModel, PersonDetailsViewViewModel>();

            IRegion toolbarRegion = RegionManager.Regions[RegionNames.TOOLBAR_REGION];
            toolbarRegion.Add(new ToolbarMenuView(new ViewPatientMenuViewModel(RegionManager, Container)));

            IRegion contentRegion = RegionManager.Regions[RegionNames.CONTENT_REGION];
            contentRegion.Add(Container.Resolve<ContentView>());

            RegionManager.RegisterViewWithRegion(RegionNames.VIEWPATIENT_PERSONDETAILS_REGION, typeof(PersonDetailsView));
        }
    }
}
