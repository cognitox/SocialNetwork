using Social.App.Web.Models.Company;
using Social.App.Web.Models.Company.Forms;
using Social.App.Web.Models.Company.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.App.Web.Controllers
{
    public class CompanyController : Controller
    {
        public ActionResult Home()
        {
            var viewModel = new CompanyHomeViewModel();
            return View(viewModel);
        }

        public ActionResult _ImageSliderPartial()
        {
            var viewModel = new CompanyImageSliderViewModel()
            {
                SlideIntervalMS = 5000,
                Images = new List<SlidingImage>()
                {
                    new SlidingImage()
                    {
                        ImageURL = @"../../Content/Company/img/header-bg9.jpg",
                        Caption = @""
                    },
                    new SlidingImage()
                    {
                        ImageURL = @"../../Content/Company/img/header-bg4.jpg",
                        Caption = @""
                    },
                    new SlidingImage()
                    {
                        ImageURL = @"../../Content/Company/img/header-bg.jpg",
                        Caption = @""
                    }
                }
            };
            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult _LoginPartial()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BetaMode"]))
            {
                //in beta mode
                var viewModel = new CompanyLoginViewModel();
                viewModel.IsBetaMode = true;
                return PartialView(viewModel);
            }
            else
            {
                //in production mode
                var viewModel = new CompanyLoginViewModel();
                viewModel.IsBetaMode = false;
                return PartialView(viewModel);
            }
        }

        [ChildActionOnly]
        public ActionResult _InstructionsPartial()
        {
            var viewModel = new CompanyInstructionsViewModel()
            {
                SectionName = @"Instructions",
                SubHeading = @"Watch our video tutorials on how to use relationship capital.",
                YouTubeVideos = new List<Models.Company.YouTubeVideo>()
                {
                    new YouTubeVideo(){
                        Description = @"Everyone has a different workflow, you don't need to change yours to start using relationship capital.",
                        Header = @"Workflow Integration",
                        HeightPX = 200,
                        WidthPX = 300,
                        SourceURL = @"//www.youtube.com/embed/upzZ2oawiZI"
                    },
                    new YouTubeVideo(){
                        Description = @"Not all commitments are measured in the same way, not all commitments are of equal importance, In this video tutorial we will show you how to earn and measure your relationship capital.",
                        Header = @"Measure & Rate",
                        HeightPX = 200,
                        WidthPX = 300,
                        SourceURL = @"//www.youtube.com/embed/upzZ2oawiZI"
                    },
                    new YouTubeVideo(){
                        Description = @"View realtime analytics of where your currently at with your commitments.",
                        Header = @"Analytics & Reporting",
                        HeightPX = 200,
                        WidthPX = 300,
                        SourceURL = @"//www.youtube.com/embed/upzZ2oawiZI"
                    }
                }
            };

            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult _CompanyPartial()
        {
            var viewModel = new CompanyTimeLineViewModel()
            {
                SectionName = @"Company",
                SubHeading = @"Relationship Capital History",
                TimeLineMoments = new List<TimeLineMoment>()
                {
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/1.jpg",
                        DateOrEventHeader = @"June 2014",
                        SubHeading = @"Our Humble Beginnings",
                        Body = @"Our team began collaborating on software architecture and design."    
                    },
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/2.jpg",
                        DateOrEventHeader = @"July 2014",
                        SubHeading = @"Relationship Capital Mockups",
                        Body = @"Mockups are set in stone and created, development begins!"    
                    },
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/3.jpg",
                        DateOrEventHeader = @"August 2012",
                        SubHeading = @"Peter Wensel Joins The Team",
                        Body = "Welcome to the Team!"    
                    },
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/4.jpg",
                        DateOrEventHeader = @"September 2014",
                        SubHeading = @"Company Website",
                        Body = @"Relationship Capital public facing website, and beta sign up has been deployed."    
                    }
                }
            };
            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult _TeamPartial()
        {
            var viewModel = new CompanyTeamViewModel()
            {
                SectionName = @"The Relationship Capital Team",
                SubHeading = @"",
                TeamMissionStatement = @"Our Amazing Team!",
                TeamMembers = new List<TeamMemberProfile>()
                {
                    new TeamMemberProfile(){
                        PersonName = @"Rob Peters",
                        PositionTitle = @"Marketing",
                        PersonImageURL = @"Content/Company/img/team/rob.jpg",
                        FacebookURL = @"http://www.facebook.com/robpeters59",
                        LinkedInURL = @"https://www.linkedin.com/profile/view?id=217005&authType=NAME_SEARCH&authToken=pGr8&locale=en_US&srchid=1613240311408842701094&srchindex=1&srchtotal=763&trk=vsrp_people_res_name&trkInfo=VSRPsearchId%3A1613240311408842701094%2CVSRPtargetId%3A217005%2CVSRPcmpt%3Aprimary",
                        TwitterURL = @"http://www.twitter.com/standardoftrust"
                    },
                    new TeamMemberProfile(){
                        PersonName = @"Tom Muscarello",
                        PositionTitle = @"Project Management/ Business Analyist",
                        PersonImageURL = @"Content/Company/img/team/muscarello.jpg",
                        FacebookURL = @"https://www.facebook.com/tom.muscarello.3",
                        LinkedInURL = @"https://www.linkedin.com/profile/view?id=2661047&authType=NAME_SEARCH&authToken=hgCZ&locale=en_US&srchid=1613240311408842828316&srchindex=1&srchtotal=3&trk=vsrp_people_res_name&trkInfo=VSRPsearchId%3A1613240311408842828316%2CVSRPtargetId%3A2661047%2CVSRPcmpt%3Aprimary",
                        TwitterURL = @"https://twitter.com/tmuscare"
                    },
                    new TeamMemberProfile(){
                        PersonName = @"Justin Jarczyk",
                        PositionTitle = @"Developer",
                        PersonImageURL = @"Content/Company/img/team/justin.jpg",
                        FacebookURL = @"https://www.facebook.com/jjarczyk1",
                        LinkedInURL = @"https://www.linkedin.com/pub/justin-jarczyk/46/3a/993",
                        TwitterURL = @"https://twitter.com/JJarczyk"
                    },
                    new TeamMemberProfile(){
                        PersonName = @"Peter Wensel",
                        PositionTitle = @"Associate Developer",
                        PersonImageURL = @"Content/Company/img/team/peter.jpg",
                        FacebookURL = @"https://www.facebook.com/peter.wensel",
                        LinkedInURL = @"https://www.linkedin.com/profile/view?id=365951806&authType=NAME_SEARCH&authToken=NP9A&locale=en_US&srchid=1613240311410310962554&srchindex=1&srchtotal=1&trk=vsrp_people_res_name&trkInfo=VSRPsearchId%3A1613240311410310962554%2CVSRPtargetId%3A365951806%2CVSRPcmpt%3Aprimary",
                        TwitterURL = @"https://twitter.com/PeterCat123"
                    }
                }
            };
            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult _ClientsPartial()
        {
            var viewModel = new CompanyClientsViewModel()
            {
                ClientImages = new List<ClientImage>()
                {
                    new ClientImage(){
                        ImageURL = @"Content/Company/img/logos/standardoftrust.jpg",
                        ClientWebsiteURL = @"#"
                    }
                }
            };
            return PartialView(viewModel);
        }


        [ChildActionOnly]
        public ActionResult _ContactPartial()
        {
            var viewModel = new CompanyContactViewModel()
            {
                SectionName = @"Contact Us",
                SubHeading = @"With... Further Questions On How Your Company Can Benefit."
            };
            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult SubmitContactForm(ContactFormViewModel viewModel)
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["BetaMode"]))
            {
                try
                {
                    try
                    {
                        var context = new BetaDatabase.BetaDatabaseDataContext();
                        context.ContactUs.InsertOnSubmit(new BetaDatabase.ContactUs()
                        {
                            ContactUsID = Guid.NewGuid(),
                            Email = viewModel.Email,
                            Message = viewModel.Message,
                            Name = viewModel.Name,
                            Phone = viewModel.Phone
                        });
                        context.SubmitChanges();
                    }
                    catch (Exception e)
                    {
                        var context = new BetaDatabase.BetaDatabaseDataContext();
                        context.ContactUs.InsertOnSubmit(new BetaDatabase.ContactUs()
                        {
                            ContactUsID = Guid.NewGuid(),
                            Email = viewModel.Email,
                            Message = viewModel.Message,
                            Name = viewModel.Name,
                            Phone = viewModel.Phone
                        });
                        context.SubmitChanges();
                    }
                }
                catch (Exception)
                {

                }
                //In beta mode
                TempData["Message"] = @"Thank You For Reaching Out To Us!";
                return RedirectToAction("Home");
            }
            else
            {
                // production mode

                //TODO, complete the processing of this form
                throw new Exception(String.Format(@"{0} {1} {2} {3}"
                    , viewModel.Email
                    , viewModel.Name
                    , viewModel.Phone
                    , viewModel.Message));

                return RedirectToAction("Home");
            }
        }

    }
}
