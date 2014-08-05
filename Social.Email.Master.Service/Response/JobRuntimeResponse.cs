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
    public class JobRuntimeResponse : LogResponse, IJobRuntimeResponse
    {
        public JobRuntimeResponse()
        {
            base.IsSuccessful = true;
            TaskResponse = new LogResponse();
        }
        public ILogResponse TaskResponse { get; set; }
        
    }
}
