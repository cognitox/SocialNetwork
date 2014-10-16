using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    interface IGroupAccountStatusTypesRepository : IBaseRepository<GroupAccountStatusType> 
    {
        void TestMethod();
    }
}
