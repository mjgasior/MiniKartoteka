using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.AddNewPatientModule.Views;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.AddNewPatientModule.ViewModels;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using MiniKartoteka.Presentation.Controls;

namespace MiniKartoteka.Modules.AddNewPatientModule
{
    public class AddNewPatientModule : BaseModule
    {
        public override void Initialize()
        {
            Container.RegisterType<IContentViewViewModel, ContentViewViewModel>();

            IRegion toolbarRegion = RegionManager.Regions[RegionNames.TOOLBAR_REGION];
            toolbarRegion.Add(new ToolbarMenuView(new AddNewPatientMenuViewModel(RegionManager, Container)));

            IRegion contentRegion = RegionManager.Regions[RegionNames.CONTENT_REGION];
            contentRegion.Add(Container.Resolve<ContentView>());
        }
    }
}

