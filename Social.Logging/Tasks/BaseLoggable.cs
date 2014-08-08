using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Logging.Tasks
{
    public class BaseLoggable : ILoggable
    {
        public string Name
        {
            get;
            protected set;
        }

        public string Objective
        {
            get;
            protected set;
        }
    }
}
