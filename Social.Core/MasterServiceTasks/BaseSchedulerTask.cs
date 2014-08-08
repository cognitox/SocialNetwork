using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Common.Enumerations;
using Social.Logging.LoggingUnit.Interface;
using Social.Core.MasterServiceTasks.Interface;
using Social.Logging.Responses.Interface;
using Social.Logging.Tasks;

namespace Social.Core.MasterServiceTasks
{
    public abstract class BaseSchedulerTask : BaseLoggable, ISchedulerTask
    {
        public Int32 ExecInterval { get; set; }
        public TimeIntervalEnum TimeInterval { get; set; }
        public virtual ILogResponse Execute(Object locker)
        {
            throw new NotImplementedException("The Execute Base Task Must Be Ovveridden.");
            return null;
        }
    }
}
