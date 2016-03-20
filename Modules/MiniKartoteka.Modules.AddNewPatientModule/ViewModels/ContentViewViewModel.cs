using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using Prism.Mvvm;

namespace MiniKartoteka.Modules.AddNewPatientModule.ViewModels
{
    public class ContentViewViewModel : BindableBase, IContentViewViewModel
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
    }
}
