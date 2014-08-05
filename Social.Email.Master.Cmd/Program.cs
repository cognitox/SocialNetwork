using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Email.Master.Jobs;
using Social.Email.Master.Jobs.Interface;
using Social.Logging.LoggingUnit;
using Social.Core.Services;

namespace Social.Email.Master.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            IJob taskSchedulerJob = new TaskSchedulerJob(new LoggingUnit(), new SchedulerService());
            taskSchedulerJob.Execute();
        }
    }
}
