using MiniKartoteka.Business.Models.Personal;

namespace MiniKartoteka.Infrastructure.Abstract.Services
{
    public interface IPatientRepository
    {
        int SavePerson(Person person);
    }
}
