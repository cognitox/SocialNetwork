using System;
namespace Social.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Social.Data.Repositories.IAccountAccountSettingsLinksRepository AccountAccountSettingsLinksRepository { get; }
        Social.Data.Repositories.IAccountCommitmentLinksRepository AccountCommitmentLinksRepository { get; }
        Social.Data.Repositories.IAccountCommitmentLinkTypesRepository AccountCommitmentLinkTypesRepository { get; }
        Social.Data.Repositories.IAccountConfigurationsRepository AccountConfigurationsRepository { get; }
        Social.Data.Repositories.IAccountGroupAccountLinksRepository AccountGroupAccountLinksRepository { get; }
        Social.Data.Repositories.IAccountMetaDatasRepository AccountMetaDatasRepository { get; }
        Social.Data.Repositories.IAccountRolesRepository AccountRolesRepository { get; }
        Social.Data.Repositories.IAccountSettingsAccountSettingsMultichoiceAnswerLinksRepository AccountSettingsAccountSettingsMultichoiceAnswerLinksRepository { get; }
        Social.Data.Repositories.IAccountSettingsMultichoiceAnswersRepository AccountSettingsMultichoiceAnswersRepository { get; }
        Social.Data.Repositories.IAccountSettingsRepository AccountSettingsRepository { get; }
        Social.Data.Repositories.IAccountSettingsTypesRepository AccountSettingsTypesRepository { get; }
        Social.Data.Repositories.IAccountsRepository AccountsRepository { get; }
        Social.Data.Repositories.IAccountStatusTypesRepository AccountStatusTypesRepository { get; }
        Social.Data.Repositories.IAccountTypesRepository AccountTypesRepository { get; }
        Social.Data.Repositories.ICommitmentGroupsRepository CommitmentGroupsRepository { get; }
        Social.Data.Repositories.ICommitmentGroupStatusTypesRepository CommitmentGroupStatusTypesRepository { get; }
        Social.Data.Repositories.ICommitmentNotesRepository CommitmentNotesRepository { get; }
        Social.Data.Repositories.ICommitmentNoteTypesRepository CommitmentNoteTypesRepository { get; }
        Social.Data.Repositories.ICommitmentQuestionnaireLinksRepository CommitmentQuestionnaireLinksRepository { get; }
        Social.Data.Repositories.ICommitmentQuestionnaireLinkTypesRepository CommitmentQuestionnaireLinkTypesRepository { get; }
        Social.Data.Repositories.ICommitmentsRepository CommitmentsRepository { get; }
        Social.Data.Repositories.ICommitmentStatusTypesRepository CommitmentStatusTypesRepository { get; }
        Social.Data.Repositories.ICommitmentTypesRepository CommitmentTypesRepository { get; }
        Social.Data.Repositories.ICommitmentTypeSubTypesRepository CommitmentTypeSubTypesRepository { get; }
        void Dispose();
        Social.Data.Repositories.IGroupAccountConfigurationsRepository GroupAccountConfigurationsRepository { get; }
        Social.Data.Repositories.IGroupAccountGroupAccountSettingsLinksRepository GroupAccountGroupAccountSettingsLinksRepository { get; }
        Social.Data.Repositories.IGroupAccountMetaDatasRepository GroupAccountMetaDatasRepository { get; }
        Social.Data.Repositories.IGroupAccountRolesRepository GroupAccountRolesRepository { get; }
        Social.Data.Repositories.IGroupAccountSettingsRepository GroupAccountSettingsRepository { get; }
        Social.Data.Repositories.IGroupAccountSettingsTypesRepository GroupAccountSettingsTypesRepository { get; }
        Social.Data.Repositories.IGroupAccountsRepository GroupAccountsRepository { get; }
        Social.Data.Repositories.IGroupAccountStatusTypesRepository GroupAccountStatusTypesRepository { get; }
        Social.Data.Repositories.IGroupAccountTypesRepository GroupAccountTypesRepository { get; }
        Social.Data.Repositories.IPaymentPlanAccountFeesRepository PaymentPlanAccountFeesRepository { get; }
        Social.Data.Repositories.IPaymentPlanAccountsRepository PaymentPlanAccountsRepository { get; }
        Social.Data.Repositories.IPaymentPlanGroupAccountFeesRepository PaymentPlanGroupAccountFeesRepository { get; }
        Social.Data.Repositories.IPaymentPlanGroupAccountsRepository PaymentPlanGroupAccountsRepository { get; }
        Social.Data.Repositories.IQuestionnaireQuestionAnswerTypesRepository QuestionnaireQuestionAnswerTypesRepository { get; }
        Social.Data.Repositories.IQuestionnaireQuestionMultichoiceAnswersRepository QuestionnaireQuestionMultichoiceAnswersRepository { get; }
        Social.Data.Repositories.IQuestionnaireQuestionnaireQuestionLinksRepository QuestionnaireQuestionnaireQuestionLinksRepository { get; }
        Social.Data.Repositories.IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository { get; }
        Social.Data.Repositories.IQuestionnaireQuestionsRepository QuestionnaireQuestionsRepository { get; }
        Social.Data.Repositories.IQuestionnaireQuestionTypesRepository QuestionnaireQuestionTypesRepository { get; }
        Social.Data.Repositories.IQuestionnairesRepository QuestionnairesRepository { get; }
        Social.Data.Repositories.IQuestionnaireTypesRepository QuestionnaireTypesRepository { get; }
        Social.Data.Repositories.IRCAccountBalancesRepository RCAccountBalancesRepository { get; }
        Social.Data.Repositories.IRCAccountTransactionsRepository RCAccountTransactionsRepository { get; }
    }
}
