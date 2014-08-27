using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Application.ViewModels
{
    public class ProfileFooterViewModel
    {
        public String Copyright { get; set; }
        public String CopyrightURL { get; set; }
        public String FooterText { get; set; }

        public FacebookHandle FacebookHandle { get; set; }
        public TwitterHandle TwitterHandle { get; set; }
        public GoogleHandle GoogleHandle { get; set; }

    }
}