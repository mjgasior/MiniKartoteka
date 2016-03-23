using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels;
using Prism.Mvvm;

namespace MiniKartoteka.Modules.ViewPatientModule.ViewModels
{
    public class PersonDetailsViewViewModel : BindableBase, IPersonDetailsViewViewModel
    {
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }
    }
}
