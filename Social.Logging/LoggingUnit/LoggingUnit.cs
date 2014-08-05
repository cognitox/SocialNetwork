using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.LoggingUnit.Interface;
using Social.Logging.Logger;

namespace Social.Logging.LoggingUnit
{
    public class LoggingUnit : ILoggingUnit
    {

        public Logger.Interface.IDatabaseLogger DatabaseLogger
        {
            get { return new DatabaseLogger(); }// { throw new NotImplementedException(); }
        }

        public Logger.Interface.IEventViewerLogger EventViewerLogger
        {
            get { return new EventViewerLogger(); }// { throw new NotImplementedException(); }
        }

        public Logger.Interface.IServiceLogger ServiceLogger
        {
            get { return new ServiceLogger(); }// { throw new NotImplementedException(); }
        }

        public void Log(Enumeration.LogStatusEnum status, Tasks.ILoggable loggable, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void LogMessage(Tasks.ILoggable loggable, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void LogInformation(Tasks.ILoggable loggable, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void LogError(Tasks.ILoggable loggable, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void Log(Enumeration.LogStatusEnum status, Responses.Interface.ILogResponse response, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void LogMessage(Responses.Interface.ILogResponse response, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void LogInformation(Responses.Interface.ILogResponse response, string message = @"")
        {
            //throw new NotImplementedException();
        }

        public void LogError(Responses.Interface.ILogResponse response, string message = @"")
        {
            //throw new NotImplementedException();
        }
    }
}
