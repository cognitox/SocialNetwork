using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company.ViewModels
{
    public class CompanyImageSliderViewModel
    {
        public List<SlidingImage> Images { get; set; }
        public Int32 SlideIntervalMS { get; set; }
    }
}