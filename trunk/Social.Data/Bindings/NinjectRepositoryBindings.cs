using Ninject.Modules;
using Social.Data.Repositories;
using Social.Data.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Bindings
{
    public class NinjectRepositoryBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountAccountSettingsLinksRepository>().To<AccountAccountSettingsLinksRepository>();
            Bind<IAccountCommitmentLinksRepository>().To<AccountCommitmentLinksRepository>();
            Bind<IAccountCommitmentLinkTypesRepository>().To<AccountCommitmentLinkTypesRepository>();
            Bind<IAccountConfigurationsRepository>().To<AccountConfigurationsRepository>();
            Bind<IAccountGroupAccountLinksRepository>().To<AccountGroupAccountLinksRepository>();
            Bind<IAccountMetaDatasRepository>().To<AccountMetaDatasRepository>();
            Bind<IAccountRolesRepository>().To<AccountRolesRepository>();
            Bind<IAccountSettingsAccountSettingsMultichoiceAnswerLinksRepository>().To<AccountSettingsAccountSettingsMultichoiceAnswerLinksRepository>();
            Bind<IAccountSettingsMultichoiceAnswersRepository>().To<AccountSettingsMultichoiceAnswersRepository>();
            Bind<IAccountSettingsRepository>().To<AccountSettingsRepository>();
            Bind<IAccountSettingsTypesRepository>().To<AccountSettingsTypesRepository>();
            Bind<IAccountsRepository>().To<AccountsRepository>();
            Bind<IAccountStatusTypesRepository>().To<AccountStatusTypesRepository>();
            Bind<IAccountTypesRepository>().To<AccountTypesRepository>();
            Bind<ICommitmentGroupsRepository>().To<CommitmentGroupsRepository>();
            Bind<ICommitmentGroupStatusTypesRepository>().To<CommitmentGroupStatusTypesRepository>();
            Bind<ICommitmentNotesRepository>().To<CommitmentNotesRepository>();
            Bind<ICommitmentNoteTypesRepository>().To<CommitmentNoteTypesRepository>();
            Bind<ICommitmentQuestionnaireLinksRepository>().To<CommitmentQuestionnaireLinksRepository>();
            Bind<ICommitmentQuestionnaireLinkTypesRepository>().To<CommitmentQuestionnaireLinkTypesRepository>();
            Bind<ICommitmentsRepository>().To<CommitmentsRepository>();
            Bind<ICommitmentStatusTypesRepository>().To<CommitmentStatusTypesRepository>();
            Bind<ICommitmentTypesRepository>().To<CommitmentTypesRepository>();
            Bind<ICommitmentTypeSubTypesRepository>().To<CommitmentTypeSubTypesRepository>();
            Bind<IGroupAccountConfigurationsRepository>().To<GroupAccountConfigurationsRepository>();
            Bind<IGroupAccountGroupAccountSettingsLinksRepository>().To<GroupAccountGroupAccountSettingsLinksRepository>();
            Bind<IGroupAccountMetaDatasRepository>().To<GroupAccountMetaDatasRepository>();
            Bind<IGroupAccountRolesRepository>().To<GroupAccountRolesRepository>();
            Bind<IGroupAccountSettingsRepository>().To<GroupAccountSettingsRepository>();
            Bind<IGroupAccountSettingsTypesRepository>().To<GroupAccountSettingsTypesRepository>();
            Bind<IGroupAccountsRepository>().To<GroupAccountsRepository>();
            Bind<IGroupAccountStatusTypesRepository>().To<GroupAccountStatusTypesRepository>();
            Bind<IGroupAccountTypesRepository>().To<GroupAccountTypesRepository>();
            Bind<IPaymentPlanAccountFeesRepository>().To<PaymentPlanAccountFeesRepository>();
            Bind<IPaymentPlanAccountsRepository>().To<PaymentPlanAccountsRepository>();
            Bind<IPaymentPlanGroupAccountFeesRepository>().To<PaymentPlanGroupAccountFeesRepository>();
            Bind<IPaymentPlanGroupAccountsRepository>().To<PaymentPlanGroupAccountsRepository>();
            Bind<IQuestionnaireQuestionAnswerTypesRepository>().To<QuestionnaireQuestionAnswerTypesRepository>();
            Bind<IQuestionnaireQuestionMultichoiceAnswersRepository>().To<QuestionnaireQuestionMultichoiceAnswersRepository>();
            Bind<IQuestionnaireQuestionnaireQuestionLinksRepository>().To<QuestionnaireQuestionnaireQuestionLinksRepository>();
            Bind<IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository>().To<QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository>();
            Bind<IQuestionnaireQuestionsRepository>().To<QuestionnaireQuestionsRepository>();
            Bind<IQuestionnaireQuestionTypesRepository>().To<QuestionnaireQuestionTypesRepository>();
            Bind<IQuestionnairesRepository>().To<QuestionnairesRepository>();
            Bind<IQuestionnaireTypesRepository>().To<QuestionnaireTypesRepository>();
            Bind<IRCAccountBalancesRepository>().To<RCAccountBalancesRepository>();
            Bind<IRCAccountTransactionsRepository>().To<RCAccountTransactionsRepository>();

        }
    }
}
