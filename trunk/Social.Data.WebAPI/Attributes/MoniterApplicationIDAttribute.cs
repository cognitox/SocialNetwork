using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Social.Data.WebAPI.Attributes
{
    public class MoniterApplicationIDAttribute : ActionFilterAttribute
    {

        //
        // Summary:
        //     Occurs before the action method is invoked.
        //
        // Parameters:
        //   actionContext:
        //     The action context.
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //verify the application ID
            /* TODO://
             * need to create and check for custom headers in the application... 
             * that this web api will be requesting from, and then we will also
             * make sure that this information is also configured within the database
             * 
             * Maybe need to create a task that deauthorizes the application....
             * Place a limit on number of requests that can be made to this application
             * Place a heartbeat on the application????
             * 
             * Need to check and make sure that 
             *      Android,
             *      IOS,
             *      And other applications can be able to easily add a header to all requests
             * 
             * 
             
             */
            //<configuration>
            //  <system.webServer>
            //    <httpProtocol>
            //      <customHeaders>
            //        <add name="Content-Language" value="*" />
            //      </customHeaders>
            //    </httpProtocol>
            //  </system.webServer>
            //</configuration>

            ///NEED to update the user heartbeat everytime the user logs into the system, update the lastlogin datetime on the user account
            ///
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return null;
        }
    
        // Summary:
        //     Occurs after the action method is invoked.
        //
        // Parameters:
        //   actionExecutedContext:
        //     The action executed context.
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return null;
        }

    }
}