using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IAccountMetaDatasRepository : IBaseRepository<AccountMetaData, SDBOAppContext> 
    {
        void TestMethod();
    }
}
