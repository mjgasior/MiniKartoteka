using MiniKartoteka.Modules.AddNewPatientModule.Abstract.Views;
using System.Windows.Controls;
using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using System;
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
    }
}
