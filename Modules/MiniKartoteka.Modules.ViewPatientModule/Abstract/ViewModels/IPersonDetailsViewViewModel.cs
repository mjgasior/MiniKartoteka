using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Infrastructure.Abstract.Mvvm;

namespace MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels
{
    public interface IPersonDetailsViewViewModel : IViewModel
    {
        Person SelectedPerson { get; set; }
    }
}
