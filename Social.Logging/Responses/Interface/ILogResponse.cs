using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Logging.Responses.Interface
{
    public interface ILogResponse
    {
        Boolean IsSuccessful { get; set; }

        String Message { get; set; }

        String FormattedException { get; }

        Exception ExceptionThrown { set; }
    }
}
