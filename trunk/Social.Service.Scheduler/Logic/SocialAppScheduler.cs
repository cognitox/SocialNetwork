using Quartz;
using Quartz.Impl;
using Social.Service.Scheduler.Logic.Interface;
using Social.Service.Scheduler.Logic.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Social.Service.Scheduler.Logic
{
    public class SocialAppScheduler : ISocialAppScheduler
    {
        public void Start()
        {
            //http://docs.particular.net/nservicebus/nservicebus-step-by-step-guide#creating-the-client-project

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = schedulerFactory.GetScheduler();
            scheduler.Start();


            // Declare Jobs
            IJobDetail notifyJob = JobBuilder.Create<EmailNotificationJob>()
                .WithIdentity("NAME_QueueNotificationTasksJob", "GROUP_Notification")
                .Build();

            IJobDetail parseJob = JobBuilder.Create<EmailParseJob>()
                            .WithIdentity("NAME_QueueParseTasksJob", "GROUP_Parse")
                            .Build();

            // Create Job Triggers
            ITrigger notificationTrigger = TriggerBuilder.Create()
              .WithIdentity("TRIGGER_Notification", "GROUP_Notification")
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithIntervalInSeconds(1)
                  .RepeatForever())
              .Build();

            ITrigger parseTrigger = TriggerBuilder.Create()
                .WithIdentity("NAME_QueueParseTasksJob", "GROUP_Parse")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(1)
                    .RepeatForever())
                .Build();


            //Register Jobs To Triggers

            //scheduler.ScheduleJob(notifyJob, notificationTrigger);
            scheduler.ScheduleJob(parseJob, parseTrigger);

            //put the current thread to sleep
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
