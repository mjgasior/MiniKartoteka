using MiniKartoteka.Infrastructure.Abstract.Mvvm;

namespace MiniKartoteka.Modules.StatusBar.Abstract.ViewModels
{
    public interface IStatusBarViewViewModel : IViewModel
    {
        string Status { get; set; }
    }
}
