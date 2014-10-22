using NUnit.Framework;
using Social.Core.Services.Database;
using Social.Core.UnitOfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.UnitTests.UnitOfService
{
    [TestFixture]

    public class UnitOfService_TestSuite
    {

        [Test]
        public void UnitOfServiceCtorTest()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            Assert.IsNotNull(unitOfService);
        }
        [Test]
        public void AccountAccountSettingsLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountAccountSettingsLinksService Service = unitOfService.AccountAccountSettingsLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountCommitmentLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountCommitmentLinksService Service = unitOfService.AccountCommitmentLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountCommitmentLinkTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountCommitmentLinkTypesService Service = unitOfService.AccountCommitmentLinkTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountConfigurationsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountConfigurationsService Service = unitOfService.AccountConfigurationsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountGroupAccountLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountGroupAccountLinksService Service = unitOfService.AccountGroupAccountLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountMetaDatasService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountMetaDatasService Service = unitOfService.AccountMetaDatasService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountRolesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountRolesService Service = unitOfService.AccountRolesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountSettingsAccountSettingsMultichoiceAnswerLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountSettingsAccountSettingsMultichoiceAnswerLinksService Service = unitOfService.AccountSettingsAccountSettingsMultichoiceAnswerLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountSettingsMultichoiceAnswersService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountSettingsMultichoiceAnswersService Service = unitOfService.AccountSettingsMultichoiceAnswersService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountSettingsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountSettingsService Service = unitOfService.AccountSettingsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountSettingsTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountSettingsTypesService Service = unitOfService.AccountSettingsTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountsService Service = unitOfService.AccountsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountStatusTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountStatusTypesService Service = unitOfService.AccountStatusTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void AccountTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IAccountTypesService Service = unitOfService.AccountTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentGroupsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentGroupsService Service = unitOfService.CommitmentGroupsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentGroupStatusTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentGroupStatusTypesService Service = unitOfService.CommitmentGroupStatusTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentNotesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentNotesService Service = unitOfService.CommitmentNotesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentNoteTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentNoteTypesService Service = unitOfService.CommitmentNoteTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentQuestionnaireLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentQuestionnaireLinksService Service = unitOfService.CommitmentQuestionnaireLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentQuestionnaireLinkTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentQuestionnaireLinkTypesService Service = unitOfService.CommitmentQuestionnaireLinkTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentsService Service = unitOfService.CommitmentsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentStatusTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentStatusTypesService Service = unitOfService.CommitmentStatusTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentTypesService Service = unitOfService.CommitmentTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void CommitmentTypeSubTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            ICommitmentTypeSubTypesService Service = unitOfService.CommitmentTypeSubTypesService;
            Assert.IsNotNull(Service);
        }

        [Test]
        public void GroupAccountConfigurationsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountConfigurationsService Service = unitOfService.GroupAccountConfigurationsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountGroupAccountSettingsLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountGroupAccountSettingsLinksService Service = unitOfService.GroupAccountGroupAccountSettingsLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountMetaDatasService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountMetaDatasService Service = unitOfService.GroupAccountMetaDatasService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountRolesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountRolesService Service = unitOfService.GroupAccountRolesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountSettingsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountSettingsService Service = unitOfService.GroupAccountSettingsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountSettingsTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountSettingsTypesService Service = unitOfService.GroupAccountSettingsTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountsService Service = unitOfService.GroupAccountsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountStatusTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountStatusTypesService Service = unitOfService.GroupAccountStatusTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void GroupAccountTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IGroupAccountTypesService Service = unitOfService.GroupAccountTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void PaymentPlanAccountFeesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IPaymentPlanAccountFeesService Service = unitOfService.PaymentPlanAccountFeesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void PaymentPlanAccountsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IPaymentPlanAccountsService Service = unitOfService.PaymentPlanAccountsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void PaymentPlanGroupAccountFeesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IPaymentPlanGroupAccountFeesService Service = unitOfService.PaymentPlanGroupAccountFeesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void PaymentPlanGroupAccountsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IPaymentPlanGroupAccountsService Service = unitOfService.PaymentPlanGroupAccountsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireQuestionAnswerTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireQuestionAnswerTypesService Service = unitOfService.QuestionnaireQuestionAnswerTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireQuestionMultichoiceAnswersService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireQuestionMultichoiceAnswersService Service = unitOfService.QuestionnaireQuestionMultichoiceAnswersService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireQuestionnaireQuestionLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireQuestionnaireQuestionLinksService Service = unitOfService.QuestionnaireQuestionnaireQuestionLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService Service = unitOfService.QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireQuestionsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireQuestionsService Service = unitOfService.QuestionnaireQuestionsService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireQuestionTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireQuestionTypesService Service = unitOfService.QuestionnaireQuestionTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnairesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnairesService Service = unitOfService.QuestionnairesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void QuestionnaireTypesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IQuestionnaireTypesService Service = unitOfService.QuestionnaireTypesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void RCAccountBalancesService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IRCAccountBalancesService Service = unitOfService.RCAccountBalancesService;
            Assert.IsNotNull(Service);
        }
        [Test]
        public void RCAccountTransactionsService_UnitOfService_Instantiation_Test()
        {
            IUnitOfService unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            IRCAccountTransactionsService Service = unitOfService.RCAccountTransactionsService;
            Assert.IsNotNull(Service);
        }
    }
}
