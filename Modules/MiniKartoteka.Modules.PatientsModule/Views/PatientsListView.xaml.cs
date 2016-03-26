using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Modules.PatientsModule.Views
{
    /// <summary>
    /// Interaction logic for PatientsListView.xaml
    /// </summary>
    public partial class PatientsListView : BaseView
    {
        public PatientsListView(IPatientsListViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
