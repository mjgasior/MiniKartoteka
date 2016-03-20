using MiniKartoteka.Modules.AddNewPatientModule.Abstract.Views;
using System.Windows.Controls;
using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using System;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;

namespace MiniKartoteka.Modules.AddNewPatientModule.Views
{
    /// <summary>
    /// Interaction logic for ContentView.xaml
    /// </summary>
    public partial class ContentView : UserControl, IContentView
    {
        public IViewModel ViewModel
        {
            get
            {
                return (IContentViewViewModel)DataContext;
            }

            set
            {
                DataContext = value;
            }
        }

        public ContentView()
        {
            InitializeComponent();
        }
    }
}
