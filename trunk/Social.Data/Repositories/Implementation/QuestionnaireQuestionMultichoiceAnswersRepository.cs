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

    public class QuestionnaireQuestionMultichoiceAnswersRepository : BaseRepository<QuestionnaireQuestionMultichoiceAnswer, SDBOAppContext>
    {
        public QuestionnaireQuestionMultichoiceAnswersRepository(SDBOAppContext context)
            :base(context)
        {
            
        }

    }
}