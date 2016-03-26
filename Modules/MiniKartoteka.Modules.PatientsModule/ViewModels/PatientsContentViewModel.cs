using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace MiniKartoteka.Modules.PatientsModule.ViewModels
{
    public class PatientsContentViewModel : BindableBase, IPatientsContentViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand NavigateCommand { get; set; }

        public PatientsContentViewModel(IRegionManager regionManager)
        {
            NavigateCommand = new DelegateCommand(OnNavigate);
            _regionManager = regionManager;
        }

        private void OnNavigate()
        {
            _regionManager.RequestNavigate(RegionNames.PATIENTSMODULE_CONTENT_REGION, nameof(PatientsListView));
        }
    }
}
