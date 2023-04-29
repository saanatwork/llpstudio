using LLP.BLL.IRepository;
using LLP.BLL.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace llpstudio
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IMasterRepository, MasterRepository>();
            container.RegisterType<IBookingRepository, BookingRepository>();
            container.RegisterType<IECommerceRepository, IECommerceRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}