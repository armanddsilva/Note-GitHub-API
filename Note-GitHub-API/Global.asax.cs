using Note_GitHub_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace Note_GitHub_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        #region For Session DataSource

        /// <summary>
        /// Initializes Session variable with NoteRepository model.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Session_Start()
        {
            Session.Add(NoteRepository.SESSION_KEY, new NoteRepository());
        }

        /// <summary>
        /// Makes the Session available in the API Controller.
        /// </summary>
        protected void Application_PostAuthorizeRequest()
        {
            if (IsWebApiRequest())
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            }
        }

        /// <summary>
        /// Determines if the request is for the API.
        /// </summary>
        /// <returns>true if WebAPI request, false otherwise</returns>
        private bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith("~/api");
        }

        #endregion
    }
}
