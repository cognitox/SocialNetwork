using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company.ViewModels
{
    public class CompanyTimeLineViewModel : BaseSectionViewModel
    {
        public List<TimeLineMoment> TimeLineMoments { get; set; }
    }
}