using Social.App.Web.Models.Application;
using Social.App.Web.Models.Application.ViewModels;
using Social.Core.UnitOfService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.App.Web.Controllers.Application
{
    public class ProfileController : BaseController
    {
        private readonly IUnitOfService _serviceUnit;

        public ProfileController(IUnitOfService serviceUnit)
        {
            _serviceUnit = serviceUnit;
        }

        [HttpPost]
        public ActionResult AuthenticateUser(LoginForm formModel)
        {
            //TODO Refactor this into the .net facebook, twitter, linkedin support
            return RedirectToAction("Home","Profile");
        }

        public ActionResult Home()
        {
            var viewModel = new ProfileHomeViewModel();
            return View(viewModel);
        }

        public ActionResult _SideNavigationPartial()
        {
            var viewModel = new ProfileSideNavigationPartialViewModel();
            return PartialView(viewModel);
        }

        public ActionResult _TopNavigationPartial()
        {
            var viewModel = new ProfileTopNavigationPartialViewModel();
            return PartialView(viewModel);
        }

        public ActionResult _MainContentPartial()
        {
            var viewModel = new ProfileMainContentPartialViewModel();
            return PartialView(viewModel);
        }

        public ActionResult _FooterPartial()
        {
            var viewModel = new ProfileFooterPartialViewModel();
            return PartialView(viewModel);
        }



    }
}
