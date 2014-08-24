using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Service.Scheduler.Logic.Jobs
{
    public class EmailNotificationJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Executing Queue Notification Tasks");
        }
    }
}
