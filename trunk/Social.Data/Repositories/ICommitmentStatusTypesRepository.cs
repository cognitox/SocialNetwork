using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface ICommitmentStatusTypesRepository : IBaseRepository<CommitmentStatusType, SDBOAppContext> 
    {
        void TestMethod();
    }
}
