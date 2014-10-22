using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Data.UnitOfWork;

namespace Social.Core.Services.Database.Implementation
{

    public class AccountSettingsService : BaseService<AccountSetting>, Social.Core.Services.Database.IAccountSettingsService
    {
        public AccountSettingsService(IUnitOfWork unitOfWork)
        {
            SetContext(unitOfWork);
        }
         

        public void TestMethod()
        {
            //remove this
        }

    }
}