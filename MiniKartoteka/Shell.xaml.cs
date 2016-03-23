using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using System.Windows;

namespace MiniKartoteka
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window, IView
    {
        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

        public Shell(IShellViewModel shellViewModel)
        {
            InitializeComponent();
            ViewModel = shellViewModel;
        }

    }
}
