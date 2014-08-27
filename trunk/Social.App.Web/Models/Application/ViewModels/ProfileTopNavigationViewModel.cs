using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Application.ViewModels
{
    public class ProfileTopNavigationViewModel
    {
        public String NavBarBrandLogo { get; set; }
        public String SearchText { get; set; }
        public List<TopNavigationElement> NavigationItems { get; set; }
    }
}