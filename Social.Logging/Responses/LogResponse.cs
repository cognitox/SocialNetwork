using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Social.Logging.Responses.Interface;

namespace Social.Logging.Responses
{
    public class LogResponse : ILogResponse
    {
        public Boolean IsSuccessful { get; set; }

        public String Message { get; set; }

        public String FormattedException { get; protected set; }

        public Exception ExceptionThrown
        {
            set
            {
                FormattedException = String.Format(@"Data :: {0}
                                    HelpLink :: {1}
                                    Message :: {3}
                                    Source :: {4}
                                    StackTrace :: {5}
                                    TargetSite :: {6}
                                    "
                        , value.Data.ToString()
                        , value.HelpLink.ToString()
                        , value.Message.ToString()
                        , value.Source.ToString()
                        , value.StackTrace.ToString()
                        , value.TargetSite.ToString());
                ExceptionThrown = value;
            }
        }
    }
}
