using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;
using MiniKartoteka.Infrastructure;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using MiniKartoteka.Presentation.Abstract;
using Prism.Mvvm;
using System.Linq;
using MiniKartoteka.Modules.ViewPatientModule.Views;

namespace MiniKartoteka.Modules.ViewPatientModule.ViewModels
{
    public class ViewPatientMenuViewModel : BindableBase, IToolbarMenuViewViewModel
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _container;

        public ICommand ActivateViewCommand { get; private set; }
        public string MenuName { get; private set; }

        public ViewPatientMenuViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            ActivateViewCommand = new DelegateCommand(OnActivateAddNewPatientModule);
            MenuName = "View patients";
            _regionManager = regionManager;
            _container = container;
        }

        private void OnActivateAddNewPatientModule()
        {
            IRegion region = _regionManager.Regions[RegionNames.CONTENT_REGION];
            IViewsCollection activeViews = region.ActiveViews;

            if (region.ActiveViews.Any(x => x is ContentView))
            {
                return;
            }
            else
            {
                region.ActiveViews.ForEach(x => region.Deactivate(x));
                var view = region.Views.First(x => x is ContentView);
                region.Activate(view);
            }
        }
    }
}
