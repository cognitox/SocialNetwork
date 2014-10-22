using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IRCAccountTransactionsRepository : IBaseRepository<RCAccountTransaction, SDBOAppContext> 
    {
        void TestMethod();
    }
}
