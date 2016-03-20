﻿using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.AddNewPatientModule.Views;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.Views;
using MiniKartoteka.Modules.AddNewPatientModule.ViewModels;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;

namespace MiniKartoteka.Modules.AddNewPatientModule
{
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
            _unityContainer.RegisterType<IContentViewViewModel, ContentViewViewModel>();

            //_regionManager.RegisterViewWithRegion(RegionNames.TOOLBAR_REGION, typeof(Toolbar)); // View discovery
            IRegion toolbarRegion = _regionManager.Regions[RegionNames.TOOLBAR_REGION]; // View injection
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());
            toolbarRegion.Add(_unityContainer.Resolve<ToolbarView>());

            var view = _unityContainer.Resolve<ContentView>();
            (view.ViewModel as IContentViewViewModel).Message = "My message";

            _regionManager.Regions[RegionNames.CONTENT_REGION].Add(view); // View injection
            
        }
    }
}

