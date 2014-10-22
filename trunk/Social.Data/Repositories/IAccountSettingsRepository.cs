using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IAccountSettingsRepository : IBaseRepository<AccountSetting, SDBOAppContext> 
    {
        void TestMethod();
    }
}
