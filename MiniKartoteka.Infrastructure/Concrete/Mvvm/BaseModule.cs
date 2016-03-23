using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace MiniKartoteka.Infrastructure.Concrete.Mvvm
{
    public abstract class BaseModule : IModule
    {
        public IRegionManager RegionManager { get; private set; }
        public IUnityContainer Container { get; private set; }

        public abstract void Initialize();
        public virtual void RegisterTypes()
        {

        }

        public BaseModule(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
            RegisterTypes();
        }
    }
}
