using Social.App.Web.Models.Application;
using Social.App.Web.Models.Application.ViewModels;
using Social.App.Web.Models.Company.ViewModels;
using Social.Core.UnitOfService;
using Social.Core.UnitOfService.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.App.Web.Controllers.Application
{
    public class ProfileController : BaseController
    {
        //private readonly IUnitOfService _serviceUnit;

        public ProfileController()
        {

        }
        //public ProfileController(IUnitOfService serviceUnit)
        //{
        //    _serviceUnit = serviceUnit;
        //}

        //[HttpPost]
        //public ActionResult AuthenticateUser(LoginForm formModel)
        //{

        //    if (Convert.ToBoolean(ConfigurationManager.AppSettings["BetaMode"]))
        //    {

        //        try
        //        {
        //            //Beta Mode
        //            try
        //            {
        //                var context = new BetaDatabase.BetaDatabaseDataContext();
        //                context.BetaSignUps.InsertOnSubmit(new BetaDatabase.BetaSignUp()
        //                {
        //                    BetaSignUpID = Guid.NewGuid(),
        //                    Email = formModel.Email
        //                });
        //                context.SubmitChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                var context = new BetaDatabase.BetaDatabaseDataContext();
        //                context.BetaSignUps.InsertOnSubmit(new BetaDatabase.BetaSignUp()
        //                {
        //                    BetaSignUpID = Guid.NewGuid(),
        //                    Email = formModel.Email
        //                });
        //                context.SubmitChanges();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //        }
        //        TempData["Message"] = @"Thank You For Signing Up!";
        //        return RedirectToAction("Home", "Company");
        //    }
        //    else
        //    {
        //        //Production Mode
        //        //TODO Refactor this into the .net facebook, twitter, linkedin support
        //        return RedirectToAction("Home", "Profile");
        //    }
        //}

        public ActionResult Home()
        {
            var viewModel = new ProfileHomeViewModel();
            return View(viewModel);
        }

        public ActionResult _SideNavigationPartial()
        {
            var viewModel = new ProfileSideNavigationViewModel()
            {
                CompanyName = @"",
                CompanySideText = @"Company Side Text",
                NavItems = new List<SideBarNavigationElement>()
                {
                    new SideBarNavigationElement(){
                        Name = @"Featured",
                        URL = @"#",
                        Glyphicon = @"glyphicon-list-alt",
                        IsActive = true
                    },
                    new SideBarNavigationElement(){
                        Name = @"Stories",
                        URL = @"#",
                        Glyphicon = @"glyphicon-list",
                        IsActive = false
                    },
                    new SideBarNavigationElement(){
                        Name = @"Saved",
                        URL = @"#",
                        Glyphicon = @"glyphicon-paperclip",
                        IsActive = false
                    },
                    new SideBarNavigationElement(){
                        Name = @"Refresh",
                        URL = @"#",
                        Glyphicon = @"glyphicon-refresh",
                        IsActive = false
                    }
                }
            };
            return PartialView(viewModel);
        }

        public ActionResult _TopNavigationPartial()
        {
            var viewModel = new ProfileTopNavigationViewModel()
            {
                NavBarBrandLogo = @"b",
                SearchText = @"",
                NavigationItems = new List<TopNavigationElement>()
                {
                    new TopNavigationElement(){
                        Name = @"Home",
                        Glyphicon = @"glyphicon-home",
                        URL = @"#"
                    },
                    new TopNavigationElement(){
                        Name = @"Home",
                        Glyphicon = @"glyphicon-home",
                        URL = @"#"
                    },
                    new TopNavigationElement(){
                        Name = @"Home",
                        Glyphicon = @"glyphicon-home",
                        URL = @"#"
                    },
                    new TopNavigationElement(){
                        Name = @"Home",
                        Glyphicon = @"glyphicon-home",
                        URL = @"#"
                    },
                    new TopNavigationElement(){
                        Name = @"Home",
                        Glyphicon = @"glyphicon-home",
                        URL = @"#"
                    }
                }
            };
            return PartialView(viewModel);
        }

        public ActionResult _MainContentPartial()
        {
            var viewModel = new ProfileMainContentViewModel();
            return PartialView(viewModel);
        }

        public ActionResult _FooterPartial()
        {
            var viewModel = new ProfileFooterViewModel()
            {
                Copyright = String.Format("©Copyright {0}", @DateTime.Now.Year),
                CopyrightURL = @"\",
                FooterText = @"Footer TEXT",
                FacebookHandle = new FacebookHandle()
                {
                    URL = @""
                },
                GoogleHandle = new GoogleHandle()
                {
                    URL = @""
                },
                TwitterHandle = new TwitterHandle()
                {
                    URL = @""
                }
            };
            return PartialView(viewModel);
        }
    }
}
