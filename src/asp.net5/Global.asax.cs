namespace asp.net5
{
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
 
        
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          
        }

     
       
    }
}
