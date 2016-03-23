using MiniKartoteka.Presentation.Abstract;
using MiniKartoteka.Presentation.Mvvm;

namespace MiniKartoteka.Presentation.Controls
{
    public partial class ToolbarMenuView : BaseView
    {
        public ToolbarMenuView(IToolbarMenuViewViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
        }
    }
}
