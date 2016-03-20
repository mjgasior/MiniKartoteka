﻿using MiniKartoteka.Modules.StatusBar.Abstract.ViewModels;
using Prism.Mvvm;

namespace MiniKartoteka.Modules.StatusBar.ViewModels
{
    public class StatusBarViewViewModel : BindableBase, IStatusBarViewViewModel
    {
        public string Status { get; set; }

        public StatusBarViewViewModel()
        {
            Status = "First status bar message!";
        }
    }
}
