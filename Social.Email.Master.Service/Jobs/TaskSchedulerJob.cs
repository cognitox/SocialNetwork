using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;
using Social.Logging.LoggingUnit.Interface;
using Social.Logging.Tasks;
using Social.Logging.Responses;
using Social.Email.Master.Service.Response;
using Social.Core.Services.Interface;
using Social.Core.MasterServiceTasks.Response;

namespace Social.Email.Master.Jobs.Interface
{
    public class TaskSchedulerJob : IJob, ITaskSchedulerJob, ILoggable
    {
        private readonly ILoggingUnit _loggingUnit;
        private readonly ISchedulerService _schedulerService;

        public TaskSchedulerJob(ILoggingUnit loggingUnit, ISchedulerService schedulerService)
        {
            _loggingUnit = loggingUnit;
            _schedulerService = schedulerService;
        }

        public string Name
        {
            get { return @"Task Scheduler Job"; }
        }

        public string Objective
        {
            get { return @"The objective of this program is to do stuff."; }
        }

        public ILogResponse Execute()
        {
            _loggingUnit.LogMessage(this, @"Beginning execution");
            Boolean running = true;
            var response = new JobRuntimeResponse();
            var scheduledTasks = _schedulerService.RetrieveTaskQueue();

            try
            {

                while (running &&
                    response.IsSuccessful)
                {
                    foreach (var @task in scheduledTasks)
                    {
                        try
                        {
                            response.TaskResponse = @task.Execute();
                        }
                        catch (Exception exception)
                        {
                            LogException(response.TaskResponse, exception);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogException(response as ILogResponse, exception);
            }
            _loggingUnit.LogMessage(this, @"Successfully executed");
            return (response as ILogResponse);
        }

        private void LogException(ILogResponse response, Exception exception)
        {
            response.Message = String.Format(@"The {0} has failed during execution on [{1}]."
                                            , Name
                                            , DateTime.Now);
            response.ExceptionThrown = exception;
            _loggingUnit.LogError(this);
            _loggingUnit.LogError(response);
        }

    }
}
