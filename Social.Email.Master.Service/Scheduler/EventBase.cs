using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Tasks;
using Social.Logging.Responses.Interface;
using Social.Logging.LoggingUnit.Interface;

namespace Social.Email.Master.Scheduler
{
    public class EventBase
    {
        private readonly ILoggingUnit _loggingUnit;

        public EventBase(ILoggingUnit loggingUnit)
        {
            _loggingUnit = loggingUnit;
        }
        
        /**/
        public Boolean Paused
        {
            get
            {
                //Have the configuration service grab this...
                return false;
            }
        }
        
        public Boolean Cancelling
        {
            get
            {
                //Have the configuration service grab this...
                return false;
            }
        }
        
        protected void LogException(ILoggable loggable, ILogResponse response, Exception exception, String Name)
        {
            response.Message = String.Format(@"The {0} has failed during execution on [{1}]."
                                            , Name
                                            , DateTime.Now);
            response.ExceptionThrown = exception;
            _loggingUnit.LogError(loggable);
            _loggingUnit.LogError(response);
        }


    }
}
