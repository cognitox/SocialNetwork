using Social.App.Web.Models.Company;
using Social.App.Web.Models.Company.Forms;
using Social.App.Web.Models.Company.ViewModels;
using System;
using System.Collections.Generic;
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
                SlideIntervalMS = 3000,
                Images = new List<SlidingImage>()
                {
                    new SlidingImage()
                    {
                        ImageURL = @"../../Content/Company/img/header-bg.jpg",
                        Caption = @""
                    },
                    new SlidingImage()
                    {
                        ImageURL = @"../../Content/Company/img/header-bg1.jpg",
                        Caption = @""
                    },
                    new SlidingImage()
                    {
                        ImageURL = @"../../Content/Company/img/header-bg4.jpg",
                        Caption = @""
                    }
                }
            };
            return PartialView(viewModel);
        }

        [ChildActionOnly]
        public ActionResult _LoginPartial()
        {
            var viewModel = new CompanyLoginViewModel();
            return PartialView(viewModel);
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
                        Body = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!"    
                    },
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/2.jpg",
                        DateOrEventHeader = @"August 2014",
                        SubHeading = @"Relationship Capital Mockups are Created",
                        Body = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!"    
                    },
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/3.jpg",
                        DateOrEventHeader = @"December 2012",
                        SubHeading = @"Transition to Full Service",
                        Body = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!"    
                    },
                    new TimeLineMoment(){
                        ImageSourceURL = @"Content/Company/img/about/4.jpg",
                        DateOrEventHeader = @"September 2014",
                        SubHeading = @"Beta Release",
                        Body = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Sunt ut voluptatum eius sapiente, totam reiciendis temporibus qui quibusdam, recusandae sit vero unde, sed, incidunt et ea quo dolore laudantium consectetur!"    
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
                TeamMissionStatement = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aut eaque, laboriosam veritatis, quos non quis ad perspiciatis, totam corporis ea, alias ut unde.",
                TeamMembers = new List<TeamMemberProfile>()
                {
                    new TeamMemberProfile(){
                        PersonName = @"Rob Peters",
                        PositionTitle = @"Marketing",
                        PersonImageURL = @"http://www.lharrispartners.com/wp-content/uploads/2014/03/rob-peters.jpg",
                        FacebookURL = @"http://www.facebook.com/robpeters59",
                        LinkedInURL = @"https://www.linkedin.com/profile/view?id=217005&authType=NAME_SEARCH&authToken=pGr8&locale=en_US&srchid=1613240311408842701094&srchindex=1&srchtotal=763&trk=vsrp_people_res_name&trkInfo=VSRPsearchId%3A1613240311408842701094%2CVSRPtargetId%3A217005%2CVSRPcmpt%3Aprimary",
                        TwitterURL = @"http://www.twitter.com/standardoftrust"
                    },
                    new TeamMemberProfile(){
                        PersonName = @"Tom Muscarello",
                        PositionTitle = @"Project Management/ Business Analyist",
                        PersonImageURL = @"http://facweb.cs.depaul.edu/yele/CIO-annual-events/2005spring/muscarello.jpg",
                        FacebookURL = @"https://www.facebook.com/tom.muscarello.3",
                        LinkedInURL = @"https://www.linkedin.com/profile/view?id=2661047&authType=NAME_SEARCH&authToken=hgCZ&locale=en_US&srchid=1613240311408842828316&srchindex=1&srchtotal=3&trk=vsrp_people_res_name&trkInfo=VSRPsearchId%3A1613240311408842828316%2CVSRPtargetId%3A2661047%2CVSRPcmpt%3Aprimary",
                        TwitterURL = @"https://twitter.com/tmuscare"
                    },
                    new TeamMemberProfile(){
                        PersonName = @"Justin Jarczyk",
                        PositionTitle = @"Developer",
                        PersonImageURL = @"http://www.webitects.com/content/images/people/justin.jpg",
                        FacebookURL = @"https://www.facebook.com/jjarczyk1",
                        LinkedInURL = @"https://www.linkedin.com/pub/justin-jarczyk/46/3a/993",
                        TwitterURL = @"https://twitter.com/JJarczyk"
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
                        ImageURL = @"Content/Company/img/logos/envato.jpg",
                        ClientWebsiteURL = @"#"
                    },
                    new ClientImage(){
                        ImageURL = @"Content/Company/img/logos/designmodo.jpg",
                        ClientWebsiteURL = @"#"
                    },
                    new ClientImage(){
                        ImageURL = @"Content/Company/img/logos/themeforest.jpg",
                        ClientWebsiteURL = @"#"
                    },
                    new ClientImage(){
                        ImageURL = @"Content/Company/img/logos/creative-market.jpg",
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
                SubHeading = @"Lorem ipsum dolor sit amet consectetur."
            };
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult SubmitContactForm(ContactFormViewModel viewModel)
        {
            //TODO, complete the processing of this form
            throw new Exception(String.Format(@"{0} {1} {2} {3}"
                , viewModel.Email
                , viewModel.Name
                , viewModel.Phone
                , viewModel.Message));

            var retVal = new JsonResult()
            {
                Data = viewModel
            };
            return retVal;
        }

    }
}
