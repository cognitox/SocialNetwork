using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Repositories.Implementation
{

    public class QuestionnaireQuestionTypesRepository : BaseRepository<QuestionnaireQuestionType, SDBOAppContext>, Social.Data.Repositories.IQuestionnaireQuestionTypesRepository
    {
        public QuestionnaireQuestionTypesRepository(SDBOAppContext context)
            : base()
        {
            SetContext(context);
        }

        public void TestMethod()
        {
            //remove this
        }

    }
}