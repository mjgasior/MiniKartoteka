using System;
using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Modules.AddNewPatientModule.Abstract.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Events;
using Microsoft.Practices.Unity;
using MiniKartoteka.Infrastructure;

namespace MiniKartoteka.Modules.AddNewPatientModule.ViewModels
{
    public class ContentViewViewModel : BindableBase, IContentViewViewModel
    {
        #region Properties
        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        public DelegateCommand<object> SaveCommand { get; private set; }

        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                if (_person != null)
                {
                    _person.PropertyChanged -= OnPersonPropertyChanged;
                }
                value.PropertyChanged += OnPersonPropertyChanged;
                SetProperty(ref _person, value);
            }
        }        
        #endregion Properties

        public ContentViewViewModel()
        {
            SaveCommand = new DelegateCommand<object>(OnSave, CanSave);
            Person = new Person
            {
                FirstName = "Bob",
                LastName = "Smith",
                Age = 46
            };
        }

        #region Events
        private void OnPersonPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }
        #endregion Events

        #region Commands
        private bool CanSave(object parameter)
        {
            return Person.Error == null;
        }

        private void OnSave(object parameter)
        {
            Person.LastUpdated = DateTime.Now.AddYears(Convert.ToInt32(parameter));

            EventAggregator.GetEvent<PersonUpdatedEvent>().Publish(string.Format("{0} {1} was updated!", Person.FirstName, Person.LastName));
        }
        #endregion Commands
    }
}
