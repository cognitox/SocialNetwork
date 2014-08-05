using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Core.Services.Interface;
using Social.Core.MasterServiceTasks;
using Social.Core.MasterServiceTasks.Interface;
using System.Collections;
using Social.Logging.LoggingUnit;

namespace Social.Core.Services
{
    public class SchedulerService : ISchedulerService
    {

        public IList<ISchedulerTask> RetrieveTaskQueue()
        {
            var retList = new List<ISchedulerTask>();
            retList.Add(new ParseEmailedCommitmentsTask(new LoggingUnit()));
            return retList;
        }
    }
}
