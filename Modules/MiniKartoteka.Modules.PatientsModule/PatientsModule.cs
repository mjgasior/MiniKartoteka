using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using Prism.Regions;
using Microsoft.Practices.Unity;
using MiniKartoteka.Infrastructure;
using MiniKartoteka.Modules.PatientsModule.Views;
using MiniKartoteka.Modules.PatientsModule.ViewModels;
using MiniKartoteka.Modules.PatientsModule.Abstract.ViewModels;

namespace MiniKartoteka.Modules.PatientsModule
{
    public class PatientsModule : BaseModule
    {
        public PatientsModule(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {

        }

        public override void RegisterTypes()
        {
            Container.RegisterType<IPatientsContentViewModel, PatientsContentViewModel>();
        }

        public override void Initialize()
        {
            
        }
    }
}
