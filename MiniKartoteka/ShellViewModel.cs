using Prism.Mvvm;
using Prism.Regions;

namespace MiniKartoteka
{
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
