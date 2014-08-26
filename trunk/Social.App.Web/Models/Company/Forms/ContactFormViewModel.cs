using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.Models.Company.Forms
{
    public class ContactFormViewModel
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Message { get; set; }
    }
}