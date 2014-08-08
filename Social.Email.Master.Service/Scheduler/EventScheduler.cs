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
using Social.Email.Master.Scheduler.Interface;
using Social.Email.Master.Runner;
using Social.Core.MasterServiceTasks;

namespace Social.Email.Master.Scheduler
{
    public class EventScheduler : EventBase, IEventBase, IEventScheduler, ILoggable
    {
        private readonly ILoggingUnit _loggingUnit;
        private readonly ISchedulerService _schedulerService;

        #region Constructor

        public EventScheduler(ILoggingUnit loggingUnit, ISchedulerService schedulerService)
            : base(loggingUnit)
        {
            _loggingUnit = loggingUnit;
            _schedulerService = schedulerService;
        }

        #endregion

        #region ILoggable

        public string Name { get { return @"Task Scheduler Job"; } }
        public string Objective { get { return @"The objective of this program is to do stuff."; } }

        #endregion

        public ILogResponse Execute()
        {
            _loggingUnit.LogMessage(this, @"Beginning execution");
            var response = new EventSchedulerResponse();
            var scheduledTasks = _schedulerService.RetrieveTaskQueue();

            try
            {
                while (!Paused &&
                        response.IsSuccessful)
                {
                    DateTime currentTime = DateTime.UtcNow;
                    if (!Cancelling)
                    {
                        //foreach (var @task in scheduledTasks)
                        //{
                        try
                        {
                            TaskRunner.Execute(
                                (locker) =>
                                {
                                    var task = new ParseEmailedCommitmentsTask();
                                    task.Execute(locker);
                                    var i = new LogResponse();
                                    return i;
                                });

                        }
                        catch (Exception exception)
                        {
                            LogException(this, response.ActionResponse, exception, Name);
                        }
                        //}
                    }
                }
                /*
                 handle all of the cancel tasks, 
                 * needs to block and wait for the handled tasks to complete...
                 * need to hammer out the database logic that handles cancel, paused and all of that stuff...
                 
                 */
            }
            catch (Exception exception)
            {
                ILogResponse logResponse = response;
                LogException(this, logResponse, exception, Name);
            }
            _loggingUnit.LogMessage(this, @"Successfully executed");
            ILogResponse returnResponse = response;
            return (returnResponse);
        }
    }
}
