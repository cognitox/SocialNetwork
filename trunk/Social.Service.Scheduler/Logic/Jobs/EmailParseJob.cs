using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Service.Scheduler.Logic.Jobs
{
    public class EmailParseJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //this needs to read from the tasks table, and send the job to the Queued
            //job table, 
            Console.WriteLine("Executing Queue Parse Tasks");
        }
    }
}
