using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IAccountsRepository : IBaseRepository<Account, SDBOAppContext> 
    {
        void TestMethod();
    }
}
