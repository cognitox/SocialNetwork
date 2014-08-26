using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company
{
    public class TimeLineMoment
    {
        public Boolean FaceLeft { get; set; }
        public String DateOrEventHeader { get; set; }
        public String SubHeading { get; set; }
        public String Body { get; set; }
        public String ImageSourceURL { get; set; }
    }
}