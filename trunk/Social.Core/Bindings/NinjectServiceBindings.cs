using Social.Core.Services.Database;
using Social.Core.Services.Database.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Social.Core.Bindings
{
    public class NinjectServiceBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountAccountSettingsLinksService>().To<AccountAccountSettingsLinksService>();
            Bind<IAccountCommitmentLinksService>().To<AccountCommitmentLinksService>();
            Bind<IAccountCommitmentLinkTypesService>().To<AccountCommitmentLinkTypesService>();
            Bind<IAccountConfigurationsService>().To<AccountConfigurationsService>();
            Bind<IAccountGroupAccountLinksService>().To<AccountGroupAccountLinksService>();
            Bind<IAccountMetaDatasService>().To<AccountMetaDatasService>();
            Bind<IAccountRolesService>().To<AccountRolesService>();
            Bind<IAccountSettingsAccountSettingsMultichoiceAnswerLinksService>().To<AccountSettingsAccountSettingsMultichoiceAnswerLinksService>();
            Bind<IAccountSettingsMultichoiceAnswersService>().To<AccountSettingsMultichoiceAnswersService>();
            Bind<IAccountSettingsService>().To<AccountSettingsService>();
            Bind<IAccountSettingsTypesService>().To<AccountSettingsTypesService>();
            Bind<IAccountsService>().To<AccountsService>();
            Bind<IAccountStatusTypesService>().To<AccountStatusTypesService>();
            Bind<IAccountTypesService>().To<AccountTypesService>();
            Bind<ICommitmentGroupsService>().To<CommitmentGroupsService>();
            Bind<ICommitmentGroupStatusTypesService>().To<CommitmentGroupStatusTypesService>();
            Bind<ICommitmentNotesService>().To<CommitmentNotesService>();
            Bind<ICommitmentNoteTypesService>().To<CommitmentNoteTypesService>();
            Bind<ICommitmentQuestionnaireLinksService>().To<CommitmentQuestionnaireLinksService>();
            Bind<ICommitmentQuestionnaireLinkTypesService>().To<CommitmentQuestionnaireLinkTypesService>();
            Bind<ICommitmentsService>().To<CommitmentsService>();
            Bind<ICommitmentStatusTypesService>().To<CommitmentStatusTypesService>();
            Bind<ICommitmentTypesService>().To<CommitmentTypesService>();
            Bind<ICommitmentTypeSubTypesService>().To<CommitmentTypeSubTypesService>();
            Bind<IGroupAccountConfigurationsService>().To<GroupAccountConfigurationsService>();
            Bind<IGroupAccountGroupAccountSettingsLinksService>().To<GroupAccountGroupAccountSettingsLinksService>();
            Bind<IGroupAccountMetaDatasService>().To<GroupAccountMetaDatasService>();
            Bind<IGroupAccountRolesService>().To<GroupAccountRolesService>();
            Bind<IGroupAccountSettingsService>().To<GroupAccountSettingsService>();
            Bind<IGroupAccountSettingsTypesService>().To<GroupAccountSettingsTypesService>();
            Bind<IGroupAccountsService>().To<GroupAccountsService>();
            Bind<IGroupAccountStatusTypesService>().To<GroupAccountStatusTypesService>();
            Bind<IGroupAccountTypesService>().To<GroupAccountTypesService>();
            Bind<IPaymentPlanAccountFeesService>().To<PaymentPlanAccountFeesService>();
            Bind<IPaymentPlanAccountsService>().To<PaymentPlanAccountsService>();
            Bind<IPaymentPlanGroupAccountFeesService>().To<PaymentPlanGroupAccountFeesService>();
            Bind<IPaymentPlanGroupAccountsService>().To<PaymentPlanGroupAccountsService>();
            Bind<IQuestionnaireQuestionAnswerTypesService>().To<QuestionnaireQuestionAnswerTypesService>();
            Bind<IQuestionnaireQuestionMultichoiceAnswersService>().To<QuestionnaireQuestionMultichoiceAnswersService>();
            Bind<IQuestionnaireQuestionnaireQuestionLinksService>().To<QuestionnaireQuestionnaireQuestionLinksService>();
            Bind<IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService>().To<QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService>();
            Bind<IQuestionnaireQuestionsService>().To<QuestionnaireQuestionsService>();
            Bind<IQuestionnaireQuestionTypesService>().To<QuestionnaireQuestionTypesService>();
            Bind<IQuestionnairesService>().To<QuestionnairesService>();
            Bind<IQuestionnaireTypesService>().To<QuestionnaireTypesService>();
            Bind<IRCAccountBalancesService>().To<RCAccountBalancesService>();
            Bind<IRCAccountTransactionsService>().To<RCAccountTransactionsService>();
        }
    }
}