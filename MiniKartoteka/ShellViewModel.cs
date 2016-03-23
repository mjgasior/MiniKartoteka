using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using MiniKartoteka.Infrastructure;

namespace MiniKartoteka
{
    public class ShellViewModel : BindableBase, IShellViewModel
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<object> NavigateCommand { get; private set; }

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<object>(Navigate);
            ApplicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        #region Commands
        private void Navigate(object navigatePath)
        {
            if (navigatePath != null)
            {
                _regionManager.RequestNavigate(RegionNames.CONTENT_REGION, navigatePath.ToString());
            }
        }
        #endregion Commands
    }
}
