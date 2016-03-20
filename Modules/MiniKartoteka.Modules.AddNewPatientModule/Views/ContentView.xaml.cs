using MiniKartoteka.Modules.AddNewPatientModule.Abstract.Views;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Modules.AddNewPatientModule.Views
{
    /// <summary>
    /// Interaction logic for ContentView.xaml
    /// </summary>
    public partial class ContentView : BaseView, IContentView
    {
        public ContentView(IContentViewViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
