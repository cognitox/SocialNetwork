using Social.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.UnitTests.TESTHELPERS
{
    public class AccountEntityManager
    {
        public Account MakeAccount()
        {
            return new Account()
            {
                
                AccountAccountSettingsLinks = null,
                AccountCommitmentLinks = null,
                AccountGroupAccountLinks = null,
                AccountMetaDatas = null,
                CommitmentNotes = null,
                AccountTypeID = Guid.Empty,
                AccountType = null,
                CommitmentQuestionnaireLinks =null,
                CreatedDate = DateTime.UtcNow,
                PaymentPlanAccountID = Guid.Empty,
                CommitmentQuestionnaireLinks1 = null,
                UpdatedDate = DateTime.UtcNow,
                Commitments = null,
                PaymentPlanAccount  = null,
                Email = "TESTACCOUNT@gmail.com",
                QuestionnaireQuestionMultichoiceAnswers = null,
                QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinks = null,
                QuestionnaireQuestions = null,
                RCAccountBalances  = null,
                RCAccountTransactions = null,
                RCAccountTransactions1 = null 
            };
        }
        public List<Account> MakeAccountList()
        {
            return null;
        }

    }
}
