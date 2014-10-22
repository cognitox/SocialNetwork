using NUnit.Framework;
using Social.Data.DatabaseContext;
using Social.Data.Repositories;
using Social.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.UnitTests.Repositories.UnitOfWork
{
    [TestFixture]
    public class UnitOfWork_TestSuite
    {
        
        [Test]
        public void UnitOfWorkCtorTest()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            Assert.IsNotNull(unitOfWork);
        }
        [Test]
        public void AccountAccountSettingsLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountAccountSettingsLinksRepository repository = unitOfWork.AccountAccountSettingsLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountCommitmentLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountCommitmentLinksRepository repository = unitOfWork.AccountCommitmentLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountCommitmentLinkTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountCommitmentLinkTypesRepository repository = unitOfWork.AccountCommitmentLinkTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountConfigurationsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountConfigurationsRepository repository = unitOfWork.AccountConfigurationsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountGroupAccountLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountGroupAccountLinksRepository repository = unitOfWork.AccountGroupAccountLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountMetaDatasRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountMetaDatasRepository repository = unitOfWork.AccountMetaDatasRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountRolesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountRolesRepository repository = unitOfWork.AccountRolesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountSettingsAccountSettingsMultichoiceAnswerLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountSettingsAccountSettingsMultichoiceAnswerLinksRepository repository = unitOfWork.AccountSettingsAccountSettingsMultichoiceAnswerLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountSettingsMultichoiceAnswersRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountSettingsMultichoiceAnswersRepository repository = unitOfWork.AccountSettingsMultichoiceAnswersRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountSettingsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountSettingsRepository repository = unitOfWork.AccountSettingsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountSettingsTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountSettingsTypesRepository repository = unitOfWork.AccountSettingsTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountsRepository repository = unitOfWork.AccountsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountStatusTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountStatusTypesRepository repository = unitOfWork.AccountStatusTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void AccountTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IAccountTypesRepository repository = unitOfWork.AccountTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentGroupsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentGroupsRepository repository = unitOfWork.CommitmentGroupsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentGroupStatusTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentGroupStatusTypesRepository repository = unitOfWork.CommitmentGroupStatusTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentNotesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentNotesRepository repository = unitOfWork.CommitmentNotesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentNoteTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentNoteTypesRepository repository = unitOfWork.CommitmentNoteTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentQuestionnaireLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentQuestionnaireLinksRepository repository = unitOfWork.CommitmentQuestionnaireLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentQuestionnaireLinkTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentQuestionnaireLinkTypesRepository repository = unitOfWork.CommitmentQuestionnaireLinkTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentsRepository repository = unitOfWork.CommitmentsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentStatusTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentStatusTypesRepository repository = unitOfWork.CommitmentStatusTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentTypesRepository repository = unitOfWork.CommitmentTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void CommitmentTypeSubTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            ICommitmentTypeSubTypesRepository repository = unitOfWork.CommitmentTypeSubTypesRepository;
            Assert.IsNotNull(repository);
        }

        [Test]
        public void GroupAccountConfigurationsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountConfigurationsRepository repository = unitOfWork.GroupAccountConfigurationsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountGroupAccountSettingsLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountGroupAccountSettingsLinksRepository repository = unitOfWork.GroupAccountGroupAccountSettingsLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountMetaDatasRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountMetaDatasRepository repository = unitOfWork.GroupAccountMetaDatasRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountRolesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountRolesRepository repository = unitOfWork.GroupAccountRolesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountSettingsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountSettingsRepository repository = unitOfWork.GroupAccountSettingsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountSettingsTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountSettingsTypesRepository repository = unitOfWork.GroupAccountSettingsTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountsRepository repository = unitOfWork.GroupAccountsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountStatusTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountStatusTypesRepository repository = unitOfWork.GroupAccountStatusTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void GroupAccountTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IGroupAccountTypesRepository repository = unitOfWork.GroupAccountTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void PaymentPlanAccountFeesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IPaymentPlanAccountFeesRepository repository = unitOfWork.PaymentPlanAccountFeesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void PaymentPlanAccountsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IPaymentPlanAccountsRepository repository = unitOfWork.PaymentPlanAccountsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void PaymentPlanGroupAccountFeesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IPaymentPlanGroupAccountFeesRepository repository = unitOfWork.PaymentPlanGroupAccountFeesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void PaymentPlanGroupAccountsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IPaymentPlanGroupAccountsRepository repository = unitOfWork.PaymentPlanGroupAccountsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireQuestionAnswerTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireQuestionAnswerTypesRepository repository = unitOfWork.QuestionnaireQuestionAnswerTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireQuestionMultichoiceAnswersRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireQuestionMultichoiceAnswersRepository repository = unitOfWork.QuestionnaireQuestionMultichoiceAnswersRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireQuestionnaireQuestionLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireQuestionnaireQuestionLinksRepository repository = unitOfWork.QuestionnaireQuestionnaireQuestionLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository repository = unitOfWork.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireQuestionsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireQuestionsRepository repository = unitOfWork.QuestionnaireQuestionsRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireQuestionTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireQuestionTypesRepository repository = unitOfWork.QuestionnaireQuestionTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnairesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnairesRepository repository = unitOfWork.QuestionnairesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void QuestionnaireTypesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IQuestionnaireTypesRepository repository = unitOfWork.QuestionnaireTypesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void RCAccountBalancesRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IRCAccountBalancesRepository repository = unitOfWork.RCAccountBalancesRepository;
            Assert.IsNotNull(repository);
        }
        [Test]
        public void RCAccountTransactionsRepository_UnitOfWork_Instantiation_Test()
        {
            IUnitOfWork unitOfWork = new Social.Data.UnitOfWork.Implementation.UnitOfWork();
            IRCAccountTransactionsRepository repository = unitOfWork.RCAccountTransactionsRepository;
            Assert.IsNotNull(repository);
        }


    }
}
