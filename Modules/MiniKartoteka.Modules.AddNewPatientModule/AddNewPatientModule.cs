using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.AddNewPatientModule.Views;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.AddNewPatientModule.ViewModels;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using MiniKartoteka.Presentation.Controls;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;

namespace MiniKartoteka.Modules.AddNewPatientModule
{
    public class AddNewPatientModule : BaseModule
    {
        public AddNewPatientModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager) { }
          
        public override void RegisterTypes()
        {
            Container.RegisterType<IContentViewViewModel, ContentViewViewModel>();
            Container.RegisterType<object, ContentView>(typeof(ContentView).FullName);
        }

        public override void Initialize()
        {
            IRegion toolbarRegion = RegionManager.Regions[RegionNames.TOOLBAR_REGION];
            toolbarRegion.Add(new ToolbarMenuView(new AddNewPatientMenuViewModel(RegionManager, Container)));

            IRegion navigationRegion = RegionManager.Regions[RegionNames.NAVIGATION_REGION];
            navigationRegion.Add(new AddNewPatientModuleButton());

            RegionManager.RegisterViewWithRegion(RegionNames.CONTENT_REGION, typeof(ContentView));
        }
    }
}

