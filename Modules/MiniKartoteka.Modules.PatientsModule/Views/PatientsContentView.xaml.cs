using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Modules.PatientsModule.Views
{
    /// <summary>
    /// Interaction logic for PatientsContentView.xaml
    /// </summary>
    public partial class PatientsContentView : BaseView
    {
        public PatientsContentView(IPatientsContentViewModel viewModel)
            : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
