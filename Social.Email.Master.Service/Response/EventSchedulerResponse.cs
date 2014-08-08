using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;
using Social.Logging.Responses;
using Social.Email.Master.Service.Response.Interface;
using Social.Core.MasterServiceTasks.Response.Interface;

namespace Social.Email.Master.Service.Response
{
    public class EventSchedulerResponse : LogResponse, IEventScheduler
    {
        public EventSchedulerResponse()
        {
            base.IsSuccessful = true;
            ActionResponse = new LogResponse();
        }
        public ILogResponse ActionResponse { get; set; }
        
    }
}
