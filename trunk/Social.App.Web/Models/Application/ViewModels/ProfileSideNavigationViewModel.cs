using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Application.ViewModels
{
    public class ProfileSideNavigationViewModel
    {
        public List<SideBarNavigationElement> NavItems { get; set; }
        //TODO:// Change the getter for this to the configuration settings
        public String CompanySideText { get; set; }
        public String CompanyName { get; set; }
    }
}