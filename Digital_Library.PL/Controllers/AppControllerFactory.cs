using Digital_Library.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

namespace Digital_Library.PL.Controllers
{
    /// <summary>
    /// Controllers factory for initialize controllers without using IoC container
    /// </summary>
    public class AppControllerFactory : DefaultControllerFactory
    {
        private readonly IServiceCreator _serviceCreator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="serviceCreator">sercices factory</param>
        public AppControllerFactory(IServiceCreator serviceCreator)
        {
            _serviceCreator = serviceCreator;
        }

        /// <summary>
        /// Create controller each request with costum params
        /// </summary>
        /// <param name="requestContext">request context</param>
        /// <param name="controllerName">controller name</param>
        /// <returns>controller object</returns>
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type type = GetControllerType(requestContext, controllerName) ?? typeof(HomeController);
            return Activator.CreateInstance(type, new Object[] { _serviceCreator}) as IController;
        }
    }
}