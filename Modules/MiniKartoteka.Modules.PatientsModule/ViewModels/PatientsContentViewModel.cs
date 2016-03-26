using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using Prism.Mvvm;

namespace MiniKartoteka.Modules.PatientsModule.ViewModels
{
    public class PatientsContentViewModel : BindableBase, IPatientsContentViewModel
    {
        public string Title { get; set; }

        public PatientsContentViewModel()
        {
            Title = "Tytuł";
        }
    }
}
