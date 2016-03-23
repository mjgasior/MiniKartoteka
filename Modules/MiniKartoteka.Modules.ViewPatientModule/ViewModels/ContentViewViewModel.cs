using System;
using System.Collections.Generic;
using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels;

namespace MiniKartoteka.Modules.ViewPatientModule.ViewModels
{
    public class ContentViewViewModel : IContentViewViewModel
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
