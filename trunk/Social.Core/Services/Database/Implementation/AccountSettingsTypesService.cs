using Social.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using Social.Core.Services.Database.Base.Implementation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Data.UnitOfWork;

namespace Social.Core.Services.Database.Implementation
{

    public class AccountSettingsTypesService : BaseService<AccountSettingsType>, Social.Core.Services.Database.IAccountSettingsTypesService
    {
        public AccountSettingsTypesService(IUnitOfWork unitOfWork)
        {
            SetContext(unitOfWork);
        }
         

        public void TestMethod()
        {
            //remove this
        }

    }
}