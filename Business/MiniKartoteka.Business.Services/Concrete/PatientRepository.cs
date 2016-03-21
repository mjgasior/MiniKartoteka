using System;
using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Infrastructure.Abstract.Services;

namespace MiniKartoteka.Business.Services.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        private int _count = 0;

        public int SavePerson(Person person)
        {
            _count++;
            person.LastUpdated = DateTime.Now;
            return _count;
        }
    }
}
