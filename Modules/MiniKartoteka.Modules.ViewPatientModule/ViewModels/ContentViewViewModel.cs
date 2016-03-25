using System;
using System.Collections.Generic;
using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels;
using Prism.Regions;

namespace MiniKartoteka.Modules.ViewPatientModule.ViewModels
{
    public class ContentViewViewModel : IContentViewViewModel, INavigationAware
    {
        public IEnumerable<Person> People
        {
            get
            {
                return new List<Person>
                {
                    MakePerson("Jonasz"),
                    MakePerson("Alber"),
                    MakePerson("Wit")
                };
            }
        }

        #region INavigationAware
        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
        #endregion INavigationAware

        private Person MakePerson(string name)
        {
            return new Person
            {
                FirstName = name,
                LastName = "Kowalski",
                Age = 27
            };
        }
    }
}
