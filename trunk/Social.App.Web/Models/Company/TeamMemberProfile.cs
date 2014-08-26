using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company
{
    public class TeamMemberProfile
    {
        public String PersonName { get; set; }
        public String PositionTitle { get; set; }
        public String PersonImageURL { get; set; }
        public String TwitterURL { get; set; }
        public String FacebookURL { get; set; }
        public String LinkedInURL { get; set; }

    }
}