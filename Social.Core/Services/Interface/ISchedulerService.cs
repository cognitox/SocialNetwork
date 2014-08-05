using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Core.MasterServiceTasks.Interface;

namespace Social.Core.Services.Interface
{
    public interface ISchedulerService
    {
        IList<ISchedulerTask> RetrieveTaskQueue();
    }
}
