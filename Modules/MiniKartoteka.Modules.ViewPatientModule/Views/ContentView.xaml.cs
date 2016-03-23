using MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Modules.ViewPatientModule.Views
{
    /// <summary>
    /// Interaction logic for ContentView.xaml
    /// </summary>
    public partial class ContentView : BaseView
    {
        public ContentView(IContentViewViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
