using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Data.UnitOfWork;

namespace Social.Core.Services.Database.Implementation
{

    public class QuestionnaireQuestionTypesService : BaseService<QuestionnaireQuestionType>, Social.Core.Services.Database.IQuestionnaireQuestionTypesService
    {
        public QuestionnaireQuestionTypesService(IUnitOfWork unitOfWork)
        {
            SetContext(unitOfWork);
        }
         

        public void TestMethod()
        {
            //remove this
        }

    }
}