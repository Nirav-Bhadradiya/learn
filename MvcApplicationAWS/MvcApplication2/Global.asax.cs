using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //register access key and secret access key for the user
            Amazon.Util.ProfileManager.RegisterProfile("demo-aws-profile", "AKIAITUBHUZMZVEINRUQ", "GyzcAV4++tPyZTtkwb9bGDCy5VZwhTJZxIUTH6kU");
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SalesErpdal>());
        }
    }
}