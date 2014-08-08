using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Core.MasterServiceTasks.Interface;
using Social.Core.MasterServiceTasks.Response;
using Social.Logging.Responses.Interface;
using Social.Common.Enumerations;
using Social.Logging.Tasks;
using Social.Logging.LoggingUnit.Interface;
using Social.Core.Services;
using Social.Logging.LoggingUnit;

namespace Social.Core.MasterServiceTasks
{
    public class ParseEmailedCommitmentsTask : BaseSchedulerTask
    {
        private readonly ILoggingUnit _loggingUnit;

        public ParseEmailedCommitmentsTask()
        {
            _loggingUnit = new LoggingUnit();
            //ILoggable
            Name = @"Parse Email Task";
            Objective = @"This task parses the configured 
                          email for commitments to create";
        }

        public ParseEmailedCommitmentsTask(ILoggingUnit loggingUnit)
        {
            _loggingUnit = loggingUnit;
            ExecInterval = 500;
            TimeInterval = TimeIntervalEnum.Milliseconds;
        }

        public override ILogResponse Execute(Object locker)
        {
            _loggingUnit.LogMessage(this, @"Beginning execution");
            var response = new TaskRuntimeResponse();
            try
            {
                //test
                lock (locker)
                {
                    TESTOBJ.Count++;
                    var i = TESTOBJ.Count.ToString();
                    Console.WriteLine(String.Format(@"Count is :: {0} ",i));
                    if (TESTOBJ.Count <= 1)
                    {
                        TESTOBJ.Count--;
                    }
                }

            }
            catch (Exception exception)
            {
                response.Message = String.Format(@"The {0} has failed during execution on [{1}]."
                                                , Name
                                                , DateTime.Now);
                response.ExceptionThrown = exception;
                _loggingUnit.LogError(this);
                ILogResponse logResponse = response;
                _loggingUnit.LogError(logResponse);
            }

            _loggingUnit.LogMessage(this, @"Successfully executed");
            ILogResponse returnResponse = response;
            return (returnResponse);
        }

    }
}
