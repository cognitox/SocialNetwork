using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;

namespace Social.Email.Master.Service.Response.Interface
{
    public interface IEventScheduler 
    {
        ILogResponse ActionResponse { get; set; }
    }
}
