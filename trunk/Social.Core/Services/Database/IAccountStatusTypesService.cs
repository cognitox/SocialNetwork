using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base;
using System;
namespace Social.Core.Services.Database
{
    public interface IAccountStatusTypesService : IBaseService<AccountStatusType> 
    {
        void TestMethod();
    }
}
