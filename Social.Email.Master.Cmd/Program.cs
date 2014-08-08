using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.LoggingUnit;
using Social.Core.Services;
using Social.Email.Master.Scheduler.Interface;
using Social.Email.Master.Scheduler;

namespace Social.Email.Master.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventBase taskSchedulerJob = new EventScheduler(new LoggingUnit(), new SchedulerService());
            taskSchedulerJob.Execute();
        }
    }
}
