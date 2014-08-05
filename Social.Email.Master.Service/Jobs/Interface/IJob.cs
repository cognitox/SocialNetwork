using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;

namespace Social.Email.Master.Jobs
{
    public interface IJob
    {
        String Name { get; }
        ILogResponse Execute();       
    }
}
