using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Modules.PatientsModule.Views
{
    /// <summary>
    /// Interaction logic for AddPatientView.xaml
    /// </summary>
    public partial class AddPatientView : BaseView
    {
        public AddPatientView(IAddPatientViewModel viewModel) 
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
