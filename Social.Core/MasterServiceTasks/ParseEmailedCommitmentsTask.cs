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

namespace Social.Core.MasterServiceTasks
{
    public class ParseEmailedCommitmentsTask : ISchedulerTask, ILoggable
    {

        public int ExecInterval { get; set; }
        public TimeIntervalEnum TimeInterval { get; set; }
        private readonly ILoggingUnit _loggingUnit;

        public ParseEmailedCommitmentsTask(ILoggingUnit loggingUnit)
        {
            _loggingUnit = loggingUnit;
            ExecInterval = 500;
            TimeInterval = TimeIntervalEnum.Milliseconds;
        }

        public string Name
        {
            get { return @"Parse Email Task"; }
        }

        public string Objective
        {
            get { return @"This task parses the configured email for commitments to create"; }
        }

        public ILogResponse Execute()
        {
            _loggingUnit.LogMessage(this, @"Beginning execution");
            var response = new TaskRuntimeResponse();
            try
            {

            }
            catch (Exception exception)
            {
                response.Message = String.Format(@"The {0} has failed during execution on [{1}]."
                                                , Name
                                                , DateTime.Now);
                response.ExceptionThrown = exception;
                _loggingUnit.LogError(this);
                _loggingUnit.LogError(response as ILogResponse);
            }

            _loggingUnit.LogMessage(this, @"Successfully executed");
            return (response as ILogResponse);
        }

    }
}
