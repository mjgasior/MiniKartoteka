using System;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.PatientsModule.Views;

namespace MiniKartoteka
{
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        public DelegateCommand Navigate { get; set; }

        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IUnityContainer container, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _container = container;

            Navigate = new DelegateCommand(OnNavigate);
        }

        private void OnNavigate()
        {
            IRegion region = _regionManager.Regions[RegionNames.TABCONTROL_REGION];
            var view = _container.Resolve<PatientsContentView>();

            region.Add(view);
            region.Activate(view);
        }
    }
}
