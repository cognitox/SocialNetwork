using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Social.Logging.LoggingUnit;
using Social.Core.Services;
using Social.Email.Master.Scheduler.Interface;
using Social.Email.Master.Scheduler;

namespace Social.Email.Master
{
    public partial class EmailMasterService : ServiceBase
    {
        public EmailMasterService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            IEventBase eventScheduler = new EventScheduler(new LoggingUnit(), new SchedulerService());
            eventScheduler.Execute();


        }

        protected override void OnStop()
        {

        }
    }
}
