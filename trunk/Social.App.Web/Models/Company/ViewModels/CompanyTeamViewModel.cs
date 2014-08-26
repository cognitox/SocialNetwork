using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company.ViewModels
{
    public class CompanyTeamViewModel: BaseSectionViewModel
    {
        public List<TeamMemberProfile> TeamMembers { get; set; }
        public String TeamMissionStatement { get; set; }
    }
}