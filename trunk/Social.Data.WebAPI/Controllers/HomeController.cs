using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.Data.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// The child window once the external provider
        /// has successfully authenticated the user.
        /// </summary>
        /// <returns></returns>
        public ActionResult LinkedInSuccessLogin()
        {
            return View();
        }
    }
}
