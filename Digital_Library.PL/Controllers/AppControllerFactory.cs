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
    public class AppControllerFactory : DefaultControllerFactory
    {
        private IServiceCreator _serviceCreator;

        public AppControllerFactory(IServiceCreator serviceCreator)
        {
            _serviceCreator = serviceCreator;
        }

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            Type type = GetControllerType(requestContext, controllerName);
            return Activator.CreateInstance(type, new Object[] { _serviceCreator}) as IController;
        }
    }
}