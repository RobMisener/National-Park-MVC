using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NPGeek.Web.DAL;


namespace NPGeek.Web
{
    public class MvcApplication : NinjectHttpApplication
    {


        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;

            // Map Interfaces to Classes
            kernel.Bind<IParkDAL>().To<ParkDAL>().WithConstructorArgument("connectionString", connectionString);
            kernel.Bind<IWeatherDAL>().To<WeatherDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }
    }
}
