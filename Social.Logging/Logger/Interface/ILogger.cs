using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Enumeration;

namespace Social.Logging.Logger.Interface
{
    public interface ILogger
    {
        void Log(LogStatusEnum status, String message);
        void LogMessage(String message);
        void LogInformation(String message);
        void LogError(String message);
    }
}
