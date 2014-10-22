using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IQuestionnaireQuestionsRepository : IBaseRepository<QuestionnaireQuestion, SDBOAppContext> 
    {
        void TestMethod();
    }
}
