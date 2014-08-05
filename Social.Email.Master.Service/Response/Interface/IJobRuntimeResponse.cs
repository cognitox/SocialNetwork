using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;

namespace Social.Email.Master.Service.Response.Interface
{
    public interface IJobRuntimeResponse 
    {
        ILogResponse TaskResponse { get; set; }
    }
}
