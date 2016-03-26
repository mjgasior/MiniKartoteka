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

        private readonly IRegionManager _regionManager;

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            Navigate = new DelegateCommand(OnNavigate);
        }

        private void OnNavigate()
        {
            _regionManager.RequestNavigate(RegionNames.TABCONTROL_REGION, "PatientsContentView");
        }
    }
}
