using System;
using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using Prism.Commands;
using Prism.Mvvm;

namespace MiniKartoteka.Modules.AddNewPatientModule.ViewModels
{
    public class ContentViewViewModel : BindableBase, IContentViewViewModel
    {
        #region Properties
        public DelegateCommand SaveCommand { get; private set; }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set { SetProperty(ref _person, value); }
        }
        #endregion Properties

        public ContentViewViewModel()
        {
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            Person = new Person
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }

        #region Commands
        private bool CanSave()
        {
            return true;
        }

        private void OnSave()
        {
            
        }
        #endregion Commands
    }
}
