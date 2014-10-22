using System;
namespace Social.Core.UnitOfService
{
    public interface IUnitOfService
    {
        Social.Core.Services.Database.IAccountAccountSettingsLinksService AccountAccountSettingsLinksService { get; }
        Social.Core.Services.Database.IAccountCommitmentLinksService AccountCommitmentLinksService { get; }
        Social.Core.Services.Database.IAccountCommitmentLinkTypesService AccountCommitmentLinkTypesService { get; }
        Social.Core.Services.Database.IAccountConfigurationsService AccountConfigurationsService { get; }
        Social.Core.Services.Database.IAccountGroupAccountLinksService AccountGroupAccountLinksService { get; }
        Social.Core.Services.Database.IAccountMetaDatasService AccountMetaDatasService { get; }
        Social.Core.Services.Database.IAccountRolesService AccountRolesService { get; }
        Social.Core.Services.Database.IAccountSettingsAccountSettingsMultichoiceAnswerLinksService AccountSettingsAccountSettingsMultichoiceAnswerLinksService { get; }
        Social.Core.Services.Database.IAccountSettingsMultichoiceAnswersService AccountSettingsMultichoiceAnswersService { get; }
        Social.Core.Services.Database.IAccountSettingsService AccountSettingsService { get; }
        Social.Core.Services.Database.IAccountSettingsTypesService AccountSettingsTypesService { get; }
        Social.Core.Services.Database.IAccountsService AccountsService { get; }
        Social.Core.Services.Database.IAccountStatusTypesService AccountStatusTypesService { get; }
        Social.Core.Services.Database.IAccountTypesService AccountTypesService { get; }
        Social.Core.Services.Database.ICommitmentGroupsService CommitmentGroupsService { get; }
        Social.Core.Services.Database.ICommitmentGroupStatusTypesService CommitmentGroupStatusTypesService { get; }
        Social.Core.Services.Database.ICommitmentNotesService CommitmentNotesService { get; }
        Social.Core.Services.Database.ICommitmentNoteTypesService CommitmentNoteTypesService { get; }
        Social.Core.Services.Database.ICommitmentQuestionnaireLinksService CommitmentQuestionnaireLinksService { get; }
        Social.Core.Services.Database.ICommitmentQuestionnaireLinkTypesService CommitmentQuestionnaireLinkTypesService { get; }
        Social.Core.Services.Database.ICommitmentsService CommitmentsService { get; }
        Social.Core.Services.Database.ICommitmentStatusTypesService CommitmentStatusTypesService { get; }
        Social.Core.Services.Database.ICommitmentTypesService CommitmentTypesService { get; }
        Social.Core.Services.Database.ICommitmentTypeSubTypesService CommitmentTypeSubTypesService { get; }
        Social.Core.Services.Database.IGroupAccountConfigurationsService GroupAccountConfigurationsService { get; }
        Social.Core.Services.Database.IGroupAccountGroupAccountSettingsLinksService GroupAccountGroupAccountSettingsLinksService { get; }
        Social.Core.Services.Database.IGroupAccountMetaDatasService GroupAccountMetaDatasService { get; }
        Social.Core.Services.Database.IGroupAccountRolesService GroupAccountRolesService { get; }
        Social.Core.Services.Database.IGroupAccountSettingsService GroupAccountSettingsService { get; }
        Social.Core.Services.Database.IGroupAccountSettingsTypesService GroupAccountSettingsTypesService { get; }
        Social.Core.Services.Database.IGroupAccountsService GroupAccountsService { get; }
        Social.Core.Services.Database.IGroupAccountStatusTypesService GroupAccountStatusTypesService { get; }
        Social.Core.Services.Database.IGroupAccountTypesService GroupAccountTypesService { get; }
        Social.Core.Services.Database.IPaymentPlanAccountFeesService PaymentPlanAccountFeesService { get; }
        Social.Core.Services.Database.IPaymentPlanAccountsService PaymentPlanAccountsService { get; }
        Social.Core.Services.Database.IPaymentPlanGroupAccountFeesService PaymentPlanGroupAccountFeesService { get; }
        Social.Core.Services.Database.IPaymentPlanGroupAccountsService PaymentPlanGroupAccountsService { get; }
        Social.Core.Services.Database.IQuestionnaireQuestionAnswerTypesService QuestionnaireQuestionAnswerTypesService { get; }
        Social.Core.Services.Database.IQuestionnaireQuestionMultichoiceAnswersService QuestionnaireQuestionMultichoiceAnswersService { get; }
        Social.Core.Services.Database.IQuestionnaireQuestionnaireQuestionLinksService QuestionnaireQuestionnaireQuestionLinksService { get; }
        Social.Core.Services.Database.IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService { get; }
        Social.Core.Services.Database.IQuestionnaireQuestionsService QuestionnaireQuestionsService { get; }
        Social.Core.Services.Database.IQuestionnaireQuestionTypesService QuestionnaireQuestionTypesService { get; }
        Social.Core.Services.Database.IQuestionnairesService QuestionnairesService { get; }
        Social.Core.Services.Database.IQuestionnaireTypesService QuestionnaireTypesService { get; }
        Social.Core.Services.Database.IRCAccountBalancesService RCAccountBalancesService { get; }
        Social.Core.Services.Database.IRCAccountTransactionsService RCAccountTransactionsService { get; }
    }
}
