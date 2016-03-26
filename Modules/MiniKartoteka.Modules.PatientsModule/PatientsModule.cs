using Microsoft.Practices.Unity;
using MiniKartoteka.Modules.PatientsModule.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;
using Prism.Modularity;
using MiniKartoteka.Modules.PatientsModule.Views;

namespace MiniKartoteka.Modules.PatientsModule
{
    public class PatientsModule :IModule
    {
        private readonly IUnityContainer _container;

        public PatientsModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IPatientsContentViewModel, PatientsContentViewModel>();
            _container.RegisterType<object, PatientsContentView>(nameof(PatientsContentView));
        }
    }
}
