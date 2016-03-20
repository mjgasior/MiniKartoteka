using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.AddNewPatientModule.Views;
using MiniKartoteka.Infrastructure;

namespace MiniKartoteka.Modules.AddNewPatientModule
{
    //[Module(ModuleName = "ModuleMojPierwszy", OnDemand = true)]
    public class AddNewPatientModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public AddNewPatientModule(IUnityContainer container, IRegionManager regionManager)
        {
            _unityContainer = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            //_regionManager.RegisterViewWithRegion(RegionNames.TOOLBAR_REGION, typeof(Toolbar));
            IRegion toolbarRegion = _regionManager.Regions[RegionNames.TOOLBAR_REGION];
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());

            _regionManager.RegisterViewWithRegion(RegionNames.CONTENT_REGION, typeof(ContentView));
        }
    }
}

