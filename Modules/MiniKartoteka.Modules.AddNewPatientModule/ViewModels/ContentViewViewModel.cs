using System;
using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.Views;

namespace MiniKartoteka.Modules.AddNewPatientModule.ViewModels
{
    public class ContentViewViewModel : IContentViewViewModel
    {
        public IView View { get; set; }

        public ContentViewViewModel(IContentView view)
        {
            View = view;
            View.ViewModel = this;
        }
    }
}
