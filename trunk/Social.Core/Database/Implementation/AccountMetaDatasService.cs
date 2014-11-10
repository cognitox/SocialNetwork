using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Data.UnitOfWork;
using Social.Common.Configuration;

namespace Social.Core.Services.Database.Implementation
{

    public class AccountMetaDatasService : BaseService<AccountMetaData>, Social.Core.Services.Database.IAccountMetaDatasService
    {
        public AccountMetaDatasService(IUnitOfWork unitOfWork)
        {
            SetContext(unitOfWork);
        }

        public AccountMetaData GetAccountMetaDataByAccountID(Guid accountID)
        {
            var repository = _unitOfWork.AccountMetaDatasRepository;
            var retVal = repository.Where(a => a.AccountID == accountID);
            return retVal.FirstOrDefault();
        }
        public AccountMetaData Update(AccountMetaData model)
        {
            var repository = _unitOfWork.AccountMetaDatasRepository;
            var retVal = repository.Update(model);
            return retVal;
        }

    }
}