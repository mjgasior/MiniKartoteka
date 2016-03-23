using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels;
using MiniKartoteka.Presentation.Mvvm;
using Prism.Common;
using Prism.Regions;

namespace MiniKartoteka.Modules.ViewPatientModule.Views
{
    /// <summary>
    /// Interaction logic for PersonDetailsView.xaml
    /// </summary>
    public partial class PersonDetailsView : BaseView
    {
        public PersonDetailsView(IPersonDetailsViewViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();

            RegionContext.GetObservableContext(this).PropertyChanged += (s, e) =>
            {
                var context = (ObservableObject<object>)s;
                var selectedPerson = (Person)context.Value;
                (ViewModel as IPersonDetailsViewViewModel).SelectedPerson = selectedPerson;
            };
        }
    }
}
