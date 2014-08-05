using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Social.Email.Master.Jobs.Interface;
using Social.Logging.LoggingUnit;
using Social.Core.Services;
using Social.Email.Master.Jobs;

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
            IJob taskSchedulerJob = new TaskSchedulerJob(new LoggingUnit(), new SchedulerService());
            taskSchedulerJob.Execute();
        }

        protected override void OnStop()
        {

        }
    }
}
