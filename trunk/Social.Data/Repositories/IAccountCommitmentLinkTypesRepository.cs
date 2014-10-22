using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IAccountCommitmentLinkTypesRepository : IBaseRepository<AccountCommitmentLinkType, SDBOAppContext>
    {
        void TestMethod();
    }
}
