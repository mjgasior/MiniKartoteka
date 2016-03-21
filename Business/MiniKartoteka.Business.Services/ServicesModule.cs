using Prism.Modularity;
using Microsoft.Practices.Unity;
using MiniKartoteka.Infrastructure.Abstract.Services;
using MiniKartoteka.Business.Services.Concrete;

namespace MiniKartoteka.Business.Services
{
    public class ServicesModule : IModule
    {
        private readonly IUnityContainer _container;

        public ServicesModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            _container.RegisterType<IPatientRepository, PatientRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
