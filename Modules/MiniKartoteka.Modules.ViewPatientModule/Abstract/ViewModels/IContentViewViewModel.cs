using MiniKartoteka.Business.Models.Personal;
using MiniKartoteka.Infrastructure.Abstract.Mvvm;
using System.Collections.Generic;

namespace MiniKartoteka.Modules.ViewPatientModule.Abstract.ViewModels
{
    public interface IContentViewViewModel : IViewModel
    {
        IEnumerable<Person> People { get; }
    }
}
