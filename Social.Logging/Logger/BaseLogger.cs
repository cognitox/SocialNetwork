using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Logger.Interface;

namespace Social.Logging.Logger
{
    public abstract class BaseLogger : ILogger
    {
        public virtual void Log(Enumeration.LogStatusEnum status, string message)
        {
            throw new NotImplementedException();
        }

        public virtual void LogMessage(string message)
        {
            throw new NotImplementedException();
        }

        public virtual void LogInformation(string message)
        {
            throw new NotImplementedException();
        }

        public virtual void LogError(string message)
        {
            throw new NotImplementedException();
        }
    }
}
