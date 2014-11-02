using Social.Core.UnitOfService;
using Social.Core.UnitOfService.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Social.Data.WebAPI.Controllers.Base
{
    public class BaseApiController : ApiController
    {
        protected IUnitOfService _unitOfService;
        protected JavaScriptSerializer _jsonSerialize;
        public BaseApiController()
        {
            _unitOfService = new UnitOfService();
            _jsonSerialize = new JavaScriptSerializer();

        }
    }
}
