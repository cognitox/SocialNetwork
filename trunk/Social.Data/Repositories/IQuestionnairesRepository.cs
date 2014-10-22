using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IQuestionnairesRepository : IBaseRepository<Questionnaire, SDBOAppContext> 
    {
        void TestMethod();
    }
}
