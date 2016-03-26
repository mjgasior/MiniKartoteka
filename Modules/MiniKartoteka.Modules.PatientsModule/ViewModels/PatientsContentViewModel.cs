using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace MiniKartoteka.Modules.PatientsModule.ViewModels
{
    public class PatientsContentViewModel : BindableBase, IPatientsContentViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<Type> NavigateCommand { get; set; }

        public PatientsContentViewModel(IRegionManager regionManager)
        {
            NavigateCommand = new DelegateCommand<Type>(OnNavigate);
            _regionManager = regionManager;
        }

        private void OnNavigate(Type parameter)
        {
            _regionManager.RequestNavigate(RegionNames.PATIENTSMODULE_CONTENT_REGION, parameter.Name);
        }
    }
}
