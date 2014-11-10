using Social.Common.Configuration;
using Social.Common.Helpers;
using Social.Common.Helpers.Implementation;
using Social.Data.DatabaseContext;
using Social.Data.WebAPI.Controllers.Base;
using Social.Data.WebAPI.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Social.Data.WebAPI.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/PlatformAccount")]
    public class PlatformAccountController : BaseApiController
    {
        public PlatformAccountController()
            : base()
        {
        }

        // GET api/PlatformAccount/GetAccountIDByEmail
        [Route("GetAccountIDByEmail")]
        [HttpGet]
        public IHttpActionResult GetAccountIDByEmail(String email)
        {
            var accountsService = _unitOfService.AccountsService;
            var account = accountsService.GetAccountByEmail(email.Trim().ToLower());


            if (account != null)
            {
                return Json(account.AccountID);
            }
            return Json(@"No account exist For that email");
        }

        // POST api/PlatformAccount/LinkLinkedInAccount
        [Route("LinkLinkedInAccount")]
        [HttpPost]
        public IHttpActionResult LinkLinkedInAccount(LinkLinkedInAccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IBase64Helper base64Helper = new Base64Helper();
            var accountMetaDatasService = _unitOfService.AccountMetaDatasService;

            var accountMetaData = accountMetaDatasService.GetAccountMetaDataByAccountID(model.AccountID);

            if (accountMetaData.LinkedInID == null)
            {
                if (!accountMetaData.UserModified)
                {
                    accountMetaData.LinkedInID = model.LinkedInAccountID;
                    if (!String.IsNullOrWhiteSpace(model.Headline)) accountMetaData.Headline = model.Headline;
                    if (!String.IsNullOrWhiteSpace(model.FirstName)) accountMetaData.FirstName = model.FirstName;
                    if (!String.IsNullOrWhiteSpace(model.LastName)) accountMetaData.LastName = model.LastName;
                    if (!String.IsNullOrWhiteSpace(model.PictureUrl)) accountMetaData.ProfileImage = base64Helper.ConvertImageURLToBase64(model.PictureUrl);
                }
                else
                {
                    if (accountMetaData.Headline == null) accountMetaData.Headline = model.Headline;
                    if (accountMetaData.FirstName == null) accountMetaData.FirstName = model.FirstName;
                    if (accountMetaData.LastName == null) accountMetaData.LastName = model.LastName;
                    if (accountMetaData.ProfileImage == ProfileConfiguration.DefaultUserImage) accountMetaData.ProfileImage = base64Helper.ConvertImageURLToBase64(model.PictureUrl);
                }
                accountMetaDatasService.Update(accountMetaData);
            }
            return Json(accountMetaData.AccountID);
        }

    }
}
