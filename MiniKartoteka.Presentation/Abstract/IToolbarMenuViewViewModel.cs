using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using System.Windows.Input;

namespace MiniKartoteka.Presentation.Abstract
{
    public interface IToolbarMenuViewViewModel : IViewModel
    {
        ICommand ActivateViewCommand { get; }
        string MenuName { get; }
    }
}
