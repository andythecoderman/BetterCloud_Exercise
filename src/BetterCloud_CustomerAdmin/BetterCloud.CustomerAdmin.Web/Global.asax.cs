using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BetterCloud.CustomerAdmin.Business;
using BetterCloud.CustomerAdmin.Common;
using BetterCloud.CustomerAdmin.Common.Interfaces.Business;
using BetterCloud.CustomerAdmin.Common.Interfaces.DataAccess;
using BetterCloud.CustomerAdmin.DataAccess.MSSQL;
using Geocoding;
using Geocoding.Google;

namespace BetterCloud.CustomerAdmin.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Kernel.Instance.Bind<ICustomerBusiness, CustomerBusiness>();
            Kernel.Instance.Bind<ICustomerData, CustomerDAO>();
            Kernel.Instance.Bind<IGeocoder, GoogleGeocoder>();


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
