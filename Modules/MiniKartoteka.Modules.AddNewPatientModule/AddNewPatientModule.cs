using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.AddNewPatientModule.Views;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.AddNewPatientModule.ViewModels;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;

namespace MiniKartoteka.Modules.AddNewPatientModule
{
    public class AddNewPatientModule : BaseModule
    {
        public override void Initialize()
        {
            Container.RegisterType<IContentViewViewModel, ContentViewViewModel>();

            IRegion toolbarRegion = RegionManager.Regions[RegionNames.TOOLBAR_REGION]; // View injection
            toolbarRegion.Add(Container.Resolve<ToolbarView>());
            toolbarRegion.Add(Container.Resolve<ToolbarView>());
            toolbarRegion.Add(Container.Resolve<ToolbarView>());
            toolbarRegion.Add(Container.Resolve<ToolbarView>());
            toolbarRegion.Add(Container.Resolve<ToolbarView>());
            toolbarRegion.Add(Container.Resolve<ToolbarView>());

            var view = Container.Resolve<ContentView>();
            (view.ViewModel as IContentViewViewModel).Message = "My first message";

            IRegion contentRegion = RegionManager.Regions[RegionNames.CONTENT_REGION];
            contentRegion.Add(view); // View injection

            // Switching views
            var view2 = Container.Resolve<ContentView>();
            (view2.ViewModel as IContentViewViewModel).Message = "My second message";

            contentRegion.Add(view2);
            contentRegion.Deactivate(view);
            contentRegion.Activate(view2);
        }
    }
}

