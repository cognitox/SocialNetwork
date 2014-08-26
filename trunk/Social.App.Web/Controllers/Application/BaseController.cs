using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.App.Web.Controllers.Application
{
    public class BaseController : Controller
    {

        public BaseController()
        {

        }

        //
        // Summary:
        //     Called before the action method is invoked.
        //
        // Parameters:
        //   filterContext:
        //     Information about the current request and action.
        protected virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        //
        // Summary:
        //     Called after the action method is invoked.
        //
        // Parameters:
        //   filterContext:
        //     Information about the current request and action.
        protected virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        //
        // Summary:
        //     Called when authorization occurs.
        //
        // Parameters:
        //   filterContext:
        //     Information about the current request and action.
        protected virtual void OnAuthorization(AuthorizationContext filterContext)
        {

        }

        //
        // Summary:
        //     Called when an unhandled exception occurs in the action.
        //
        // Parameters:
        //   filterContext:
        //     Information about the current request and action.
        protected virtual void OnException(ExceptionContext filterContext)
        {

        }

        //
        // Summary:
        //     Called before the action result that is returned by an action method is executed.
        //
        // Parameters:
        //   filterContext:
        //     Information about the current request and action result
        protected virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }

        //
        // Summary:
        //     Called after the action result that is returned by an action method is executed.
        //
        // Parameters:
        //   filterContext:
        //     Information about the current request and action result
        protected virtual void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }
        
    }
}
