﻿using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using Prism.Commands;

namespace MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels
{
    public interface IPatientsContentViewModel : IViewModel
    {
        DelegateCommand NavigateCommand { get; set; }
    }
}
