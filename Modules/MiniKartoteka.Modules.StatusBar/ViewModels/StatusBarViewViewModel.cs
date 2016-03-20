using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.StatusBar.Abstract.ViewModels;
using Prism.Events;
using Prism.Mvvm;

namespace MiniKartoteka.Modules.StatusBar.ViewModels
{
    public class StatusBarViewViewModel : BindableBase, IStatusBarViewViewModel
    {
        public string Status { get; set; } = "First status bar message!";

        public StatusBarViewViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<PersonUpdatedEvent>().Subscribe(OnPersonUpdated);
        }

        private void OnPersonUpdated(string personData)
        {
            Status = personData;
            OnPropertyChanged(() => Status);
        }
    }
}
