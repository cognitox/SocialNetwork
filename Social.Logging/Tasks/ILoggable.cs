using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Logging.Tasks
{
    public interface ILoggable
    {
        String Name { get; }
        String Objective { get; }
    }
}
