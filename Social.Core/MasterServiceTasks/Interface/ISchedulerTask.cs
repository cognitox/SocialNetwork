using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses;
using Social.Core.MasterServiceTasks.Response;
using Social.Logging.Responses.Interface;
using Social.Common.Enumerations;

namespace Social.Core.MasterServiceTasks.Interface
{
    public interface ISchedulerTask
    {
        Int32 ExecInterval { get; set; }
        TimeIntervalEnum TimeInterval { get; set; }
        ILogResponse Execute(Object locker);
    }
}
