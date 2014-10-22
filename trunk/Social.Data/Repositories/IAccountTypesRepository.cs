using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IAccountTypesRepository : IBaseRepository<AccountType, SDBOAppContext> 
    {
        void TestMethod();
    }
}
