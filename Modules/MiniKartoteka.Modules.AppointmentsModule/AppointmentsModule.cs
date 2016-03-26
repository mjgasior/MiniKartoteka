using System;
using MiniKartoteka.Infrastructure.Concrete.Mvvm;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace MiniKartoteka.Modules.AppointmentsModule
{
    public class AppointmentsModule : BaseModule
    {
        public AppointmentsModule(IUnityContainer container, IRegionManager regionManager) 
            : base(container, regionManager)
        {

        }

        public override void Initialize()
        {
            
        }
    }
}
