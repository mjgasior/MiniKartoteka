using MiniKartoteka.Modules.StatusBar.Abstract.ViewModels;
using MiniKartoteka.Modules.StatusBar.Abstract.Views;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Modules.StatusBar.Views
{
    /// <summary>
    /// Interaction logic for StatusBarView.xaml
    /// </summary>
    public partial class StatusBarView : BaseView, IStatusBarView
    {
        public StatusBarView(IStatusBarViewViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
