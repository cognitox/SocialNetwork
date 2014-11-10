using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base;
using System;
namespace Social.Core.Services.Database
{
    public interface IAccountMetaDatasService : IBaseService<AccountMetaData>
    {
        AccountMetaData GetAccountMetaDataByAccountID(Guid accountID);

        AccountMetaData Update(AccountMetaData model);
    }
}
