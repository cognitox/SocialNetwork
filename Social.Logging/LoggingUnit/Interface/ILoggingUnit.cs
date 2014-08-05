using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Logger.Interface;
using Social.Logging.Enumeration;
using Social.Logging.Tasks;
using Social.Logging.Responses.Interface;

namespace Social.Logging.LoggingUnit.Interface
{
    public interface ILoggingUnit
    {
        //base loggers
        IDatabaseLogger DatabaseLogger { get; }
        IEventViewerLogger EventViewerLogger { get; }
        IServiceLogger ServiceLogger { get; }

        //ILoggable => logs executing tasks
        void Log(LogStatusEnum status, ILoggable loggable, String message = @"");
        void LogMessage(ILoggable loggable, String message = @"");
        void LogInformation(ILoggable loggable, String message = @"");
        void LogError(ILoggable loggable, String message = @"");

        //ILogResponse => logs responses
        void Log(LogStatusEnum status, ILogResponse response, String message = @"");
        void LogMessage(ILogResponse response, String message = @"");
        void LogInformation(ILogResponse response, String message = @"");
        void LogError(ILogResponse response, String message = @"");


    }
}
