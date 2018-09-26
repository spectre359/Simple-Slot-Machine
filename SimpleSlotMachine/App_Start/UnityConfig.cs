using SimpleSlotMachine.Repositories;
using SimpleSlotMachine.Repositories.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;


namespace SimpleSlotMachine.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
           container.RegisterType<ISymbolRepository, SymbolRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}