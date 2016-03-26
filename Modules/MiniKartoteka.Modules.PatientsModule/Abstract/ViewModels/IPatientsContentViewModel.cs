using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using Prism.Commands;
using System;

namespace MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels
{
    public interface IPatientsContentViewModel : IViewModel
    {
        DelegateCommand<Type> NavigateCommand { get; set; }
    }
}
