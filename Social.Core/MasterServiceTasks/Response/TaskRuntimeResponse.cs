using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses;
using Social.Core.MasterServiceTasks.Response.Interface;

namespace Social.Core.MasterServiceTasks.Response
{
    public class TaskRuntimeResponse : LogResponse, ITaskRuntimeResponse
    {
        public TaskRuntimeResponse()
        {
            base.IsSuccessful = true;
        }
    }
}
