using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base;
using System;
namespace Social.Core.Services.Database
{
    public interface IQuestionnaireQuestionTypesService : IBaseService<QuestionnaireQuestionType> 
    {
        void TestMethod();
    }
}
