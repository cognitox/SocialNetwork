using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    interface IGroupAccountSettingsTypesRepository : IBaseRepository<GroupAccountSettingsType> 
    {
        void TestMethod();
    }
}
