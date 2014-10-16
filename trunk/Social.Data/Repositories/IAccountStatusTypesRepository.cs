using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    interface IAccountStatusTypesRepository : IBaseRepository<AccountStatusType> 
    {
        void TestMethod();
    }
}
