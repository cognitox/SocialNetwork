using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;
using Social.Email.Master.Runner.ThreadScheduler;
using System.Threading.Tasks;
using System.Threading;

namespace Social.Email.Master.Runner
{
    public static class TaskRunner
    {
        private static Object locker = new Object();

        private static List<Task> scheduledTaskList = new List<Task>();

        private static Int32 NumberOfThreads
        {
            get
            {
                //TODO:// put this on a time delay and recheck every 5 minutes.
                //IConfigurationService configurationService = new ConfigurationService();
                //return configurationService.GetMasterServiceNumberOFThreads();
                return 2;
            }
        }
        public static void Execute(Func<Object, ILogResponse> schedulerTask)
        {
            CancellationTokenSource cancelationToken = new CancellationTokenSource();
            RunnerThreadScheduler threadScheduler = new RunnerThreadScheduler(NumberOfThreads);
            TaskFactory taskFactory = new TaskFactory(threadScheduler);

            //TODO://Implement multiple locks,
            // one for each type of task, then place all of the 
            // locks inside the calling method,
            // 

            Task createdTask = taskFactory.StartNew(() =>
            {
                ILogResponse response = null;
                try
                {
                    response = schedulerTask(locker);
                }
                catch (Exception exception)
                {
                    ILogResponse logResponse = response;
                    logResponse.ExceptionThrown = exception;
                    logResponse.IsSuccessful = false;
                    logResponse.Message = exception.Message;
                }
            }, cancelationToken.Token);
            scheduledTaskList.Add(createdTask);
        }
    }
}
