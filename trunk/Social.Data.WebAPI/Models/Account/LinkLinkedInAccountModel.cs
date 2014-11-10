using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Social.Data.WebAPI.Models.Account
{
    public class LinkLinkedInAccountModel
    {

        [Required]
        public Guid AccountID { get; set; }
        [Required]
        public String LinkedInAccountID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Headline { get; set; }
        public String PictureUrl { get; set; }

    }
}