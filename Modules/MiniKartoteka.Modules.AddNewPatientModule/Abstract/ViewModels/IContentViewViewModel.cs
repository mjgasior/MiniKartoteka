using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using Prism.Commands;

namespace MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels
{
    public interface IContentViewViewModel : IViewModel
    {
        DelegateCommand<object> SaveCommand { get; }
        Person Person { get; set; }
    }
}
