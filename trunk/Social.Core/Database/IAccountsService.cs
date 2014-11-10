using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base;
using System;
namespace Social.Core.Services.Database
{
    public interface IAccountsService : IBaseService<Account> 
    {
        Account CreateOrUpdateFreeStandardAccount(String username);
        Account CreateFreeStandardAccount(string loweredUsername);
        Account GetAccountByEmail(string email);
        Account GetAccountByID(Guid accountID);
    }
}
