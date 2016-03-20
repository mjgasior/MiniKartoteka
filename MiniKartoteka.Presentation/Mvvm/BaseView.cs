using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using System.Windows.Controls;

namespace MiniKartoteka.Presentation.Mvvm
{
    public class BaseView : UserControl, IView
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

        public BaseView(IViewModel viewModel)
        {
            
        }
    }
}
