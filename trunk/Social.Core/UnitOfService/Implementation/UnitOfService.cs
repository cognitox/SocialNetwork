using Ninject;
using Social.Core.Bindings;
using Social.Core.Services.Database;
using Social.Data.UnitOfWork;
using Social.Data.UnitOfWork.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Social.Core.UnitOfService.Implementation
{
    public class UnitOfService : Social.Core.UnitOfService.IUnitOfService 
    {
        private IUnitOfWork _context;
        private IKernel _kernel;
        private Ninject.Parameters.Parameter _parms;
        public UnitOfService()
        {
            //load in the bindings
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            _context = new UnitOfWork();
            _parms = new Ninject.Parameters.ConstructorArgument("context", _context);
        }

        /// <summary>
        /// Unit Test Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        public UnitOfService(IUnitOfWork unitOfWork)
        {
            //load in the bindings
            _kernel = new StandardKernel();
            _kernel.Load(Assembly.GetExecutingAssembly());
            _context = unitOfWork;
            _parms = new Ninject.Parameters.ConstructorArgument("context", _context);

        }



        private IAccountAccountSettingsLinksService _accountAccountSettingsLinksService;
        public IAccountAccountSettingsLinksService AccountAccountSettingsLinksService
        {
            get
            {
                if (null == _accountAccountSettingsLinksService)
                {
                    _accountAccountSettingsLinksService = _kernel.Get<IAccountAccountSettingsLinksService>(_parms);
                }

                return _accountAccountSettingsLinksService;
            }
        }

        private IAccountCommitmentLinksService _accountCommitmentLinksService;
        public IAccountCommitmentLinksService AccountCommitmentLinksService
        {
            get
            {
                if (null == _accountCommitmentLinksService)
                {
                    _accountCommitmentLinksService = _kernel.Get<IAccountCommitmentLinksService>(_parms);
                }

                return _accountCommitmentLinksService;
            }
        }

        private IAccountCommitmentLinkTypesService _accountCommitmentLinkTypesService;
        public IAccountCommitmentLinkTypesService AccountCommitmentLinkTypesService
        {
            get
            {
                if (null == _accountCommitmentLinkTypesService)
                {
                    _accountCommitmentLinkTypesService = _kernel.Get<IAccountCommitmentLinkTypesService>(_parms);
                }

                return _accountCommitmentLinkTypesService;
            }
        }

        private IAccountConfigurationsService _accountConfigurationsService;
        public IAccountConfigurationsService AccountConfigurationsService
        {
            get
            {
                if (null == _accountConfigurationsService)
                {
                    _accountConfigurationsService = _kernel.Get<IAccountConfigurationsService>(_parms);
                }

                return _accountConfigurationsService;
            }
        }

        private IAccountGroupAccountLinksService _accountGroupAccountLinksService;
        public IAccountGroupAccountLinksService AccountGroupAccountLinksService
        {
            get
            {
                if (null == _accountGroupAccountLinksService)
                {
                    _accountGroupAccountLinksService = _kernel.Get<IAccountGroupAccountLinksService>(_parms);
                }

                return _accountGroupAccountLinksService;
            }
        }

        private IAccountMetaDatasService _accountMetaDatasService;
        public IAccountMetaDatasService AccountMetaDatasService
        {
            get
            {
                if (null == _accountMetaDatasService)
                {
                    _accountMetaDatasService = _kernel.Get<IAccountMetaDatasService>(_parms);
                }

                return _accountMetaDatasService;
            }
        }

        private IAccountRolesService _accountRolesService;
        public IAccountRolesService AccountRolesService
        {
            get
            {
                if (null == _accountRolesService)
                {
                    _accountRolesService = _kernel.Get<IAccountRolesService>(_parms);
                }

                return _accountRolesService;
            }
        }

        private IAccountSettingsAccountSettingsMultichoiceAnswerLinksService _accountSettingsAccountSettingsMultichoiceAnswerLinksService;
        public IAccountSettingsAccountSettingsMultichoiceAnswerLinksService AccountSettingsAccountSettingsMultichoiceAnswerLinksService
        {
            get
            {
                if (null == _accountSettingsAccountSettingsMultichoiceAnswerLinksService)
                {
                    _accountSettingsAccountSettingsMultichoiceAnswerLinksService = _kernel.Get<IAccountSettingsAccountSettingsMultichoiceAnswerLinksService>(_parms);
                }

                return _accountSettingsAccountSettingsMultichoiceAnswerLinksService;
            }
        }

        private IAccountSettingsMultichoiceAnswersService _accountSettingsMultichoiceAnswersService;
        public IAccountSettingsMultichoiceAnswersService AccountSettingsMultichoiceAnswersService
        {
            get
            {
                if (null == _accountSettingsMultichoiceAnswersService)
                {
                    _accountSettingsMultichoiceAnswersService = _kernel.Get<IAccountSettingsMultichoiceAnswersService>(_parms);
                }

                return _accountSettingsMultichoiceAnswersService;
            }
        }

        private IAccountSettingsService _accountSettingsService;
        public IAccountSettingsService AccountSettingsService
        {
            get
            {
                if (null == _accountSettingsService)
                {
                    _accountSettingsService = _kernel.Get<IAccountSettingsService>(_parms);
                }

                return _accountSettingsService;
            }
        }

        private IAccountSettingsTypesService _accountSettingsTypesService;
        public IAccountSettingsTypesService AccountSettingsTypesService
        {
            get
            {
                if (null == _accountSettingsTypesService)
                {
                    _accountSettingsTypesService = _kernel.Get<IAccountSettingsTypesService>(_parms);
                }

                return _accountSettingsTypesService;
            }
        }

        private IAccountsService _accountsService;
        public IAccountsService AccountsService
        {
            get
            {
                if (null == _accountsService)
                {
                    _accountsService = _kernel.Get<IAccountsService>(_parms);
                }

                return _accountsService;
            }
        }

        private IAccountStatusTypesService _accountStatusTypesService;
        public IAccountStatusTypesService AccountStatusTypesService
        {
            get
            {
                if (null == _accountStatusTypesService)
                {
                    _accountStatusTypesService = _kernel.Get<IAccountStatusTypesService>(_parms);
                }

                return _accountStatusTypesService;
            }
        }

        private IAccountTypesService _accountTypesService;
        public IAccountTypesService AccountTypesService
        {
            get
            {
                if (null == _accountTypesService)
                {
                    _accountTypesService = _kernel.Get<IAccountTypesService>(_parms);
                }

                return _accountTypesService;
            }
        }

        private ICommitmentGroupsService _commitmentGroupsService;
        public ICommitmentGroupsService CommitmentGroupsService
        {
            get
            {
                if (null == _commitmentGroupsService)
                {
                    _commitmentGroupsService = _kernel.Get<ICommitmentGroupsService>(_parms);
                }

                return _commitmentGroupsService;
            }
        }

        private ICommitmentGroupStatusTypesService _commitmentGroupStatusTypesService;
        public ICommitmentGroupStatusTypesService CommitmentGroupStatusTypesService
        {
            get
            {
                if (null == _commitmentGroupStatusTypesService)
                {
                    _commitmentGroupStatusTypesService = _kernel.Get<ICommitmentGroupStatusTypesService>(_parms);
                }

                return _commitmentGroupStatusTypesService;
            }
        }

        private ICommitmentNotesService _commitmentNotesService;
        public ICommitmentNotesService CommitmentNotesService
        {
            get
            {
                if (null == _commitmentNotesService)
                {
                    _commitmentNotesService = _kernel.Get<ICommitmentNotesService>(_parms);
                }

                return _commitmentNotesService;
            }
        }

        private ICommitmentNoteTypesService _commitmentNoteTypesService;
        public ICommitmentNoteTypesService CommitmentNoteTypesService
        {
            get
            {
                if (null == _commitmentNoteTypesService)
                {
                    _commitmentNoteTypesService = _kernel.Get<ICommitmentNoteTypesService>(_parms);
                }

                return _commitmentNoteTypesService;
            }
        }

        private ICommitmentQuestionnaireLinksService _commitmentQuestionnaireLinksService;
        public ICommitmentQuestionnaireLinksService CommitmentQuestionnaireLinksService
        {
            get
            {
                if (null == _commitmentQuestionnaireLinksService)
                {
                    _commitmentQuestionnaireLinksService = _kernel.Get<ICommitmentQuestionnaireLinksService>(_parms);
                }

                return _commitmentQuestionnaireLinksService;
            }
        }

        private ICommitmentQuestionnaireLinkTypesService _commitmentQuestionnaireLinkTypesService;
        public ICommitmentQuestionnaireLinkTypesService CommitmentQuestionnaireLinkTypesService
        {
            get
            {
                if (null == _commitmentQuestionnaireLinkTypesService)
                {
                    _commitmentQuestionnaireLinkTypesService = _kernel.Get<ICommitmentQuestionnaireLinkTypesService>(_parms);
                }

                return _commitmentQuestionnaireLinkTypesService;
            }
        }

        private ICommitmentsService _commitmentsService;
        public ICommitmentsService CommitmentsService
        {
            get
            {
                if (null == _commitmentsService)
                {
                    _commitmentsService = _kernel.Get<ICommitmentsService>(_parms);
                }

                return _commitmentsService;
            }
        }

        private ICommitmentStatusTypesService _commitmentStatusTypesService;
        public ICommitmentStatusTypesService CommitmentStatusTypesService
        {
            get
            {
                if (null == _commitmentStatusTypesService)
                {
                    _commitmentStatusTypesService = _kernel.Get<ICommitmentStatusTypesService>(_parms);
                }

                return _commitmentStatusTypesService;
            }
        }

        private ICommitmentTypesService _commitmentTypesService;
        public ICommitmentTypesService CommitmentTypesService
        {
            get
            {
                if (null == _commitmentTypesService)
                {
                    _commitmentTypesService = _kernel.Get<ICommitmentTypesService>(_parms);
                }

                return _commitmentTypesService;
            }
        }

        private ICommitmentTypeSubTypesService _commitmentTypeSubTypesService;
        public ICommitmentTypeSubTypesService CommitmentTypeSubTypesService
        {
            get
            {
                if (null == _commitmentTypeSubTypesService)
                {
                    _commitmentTypeSubTypesService = _kernel.Get<ICommitmentTypeSubTypesService>(_parms);
                }

                return _commitmentTypeSubTypesService;
            }
        }

        private IGroupAccountConfigurationsService _groupAccountConfigurationsService;
        public IGroupAccountConfigurationsService GroupAccountConfigurationsService
        {
            get
            {
                if (null == _groupAccountConfigurationsService)
                {
                    _groupAccountConfigurationsService = _kernel.Get<IGroupAccountConfigurationsService>(_parms);
                }

                return _groupAccountConfigurationsService;
            }
        }

        private IGroupAccountGroupAccountSettingsLinksService _groupAccountGroupAccountSettingsLinksService;
        public IGroupAccountGroupAccountSettingsLinksService GroupAccountGroupAccountSettingsLinksService
        {
            get
            {
                if (null == _groupAccountGroupAccountSettingsLinksService)
                {
                    _groupAccountGroupAccountSettingsLinksService = _kernel.Get<IGroupAccountGroupAccountSettingsLinksService>(_parms);
                }

                return _groupAccountGroupAccountSettingsLinksService;
            }
        }

        private IGroupAccountMetaDatasService _groupAccountMetaDatasService;
        public IGroupAccountMetaDatasService GroupAccountMetaDatasService
        {
            get
            {
                if (null == _groupAccountMetaDatasService)
                {
                    _groupAccountMetaDatasService = _kernel.Get<IGroupAccountMetaDatasService>(_parms);
                }

                return _groupAccountMetaDatasService;
            }
        }

        private IGroupAccountRolesService _groupAccountRolesService;
        public IGroupAccountRolesService GroupAccountRolesService
        {
            get
            {
                if (null == _groupAccountRolesService)
                {
                    _groupAccountRolesService = _kernel.Get<IGroupAccountRolesService>(_parms);
                }

                return _groupAccountRolesService;
            }
        }

        private IGroupAccountSettingsService _groupAccountSettingsService;
        public IGroupAccountSettingsService GroupAccountSettingsService
        {
            get
            {
                if (null == _groupAccountSettingsService)
                {
                    _groupAccountSettingsService = _kernel.Get<IGroupAccountSettingsService>(_parms);
                }

                return _groupAccountSettingsService;
            }
        }

        private IGroupAccountSettingsTypesService _groupAccountSettingsTypesService;
        public IGroupAccountSettingsTypesService GroupAccountSettingsTypesService
        {
            get
            {
                if (null == _groupAccountSettingsTypesService)
                {
                    _groupAccountSettingsTypesService = _kernel.Get<IGroupAccountSettingsTypesService>(_parms);
                }

                return _groupAccountSettingsTypesService;
            }
        }

        private IGroupAccountsService _groupAccountsService;
        public IGroupAccountsService GroupAccountsService
        {
            get
            {
                if (null == _groupAccountsService)
                {
                    _groupAccountsService = _kernel.Get<IGroupAccountsService>(_parms);
                }

                return _groupAccountsService;
            }
        }

        private IGroupAccountStatusTypesService _groupAccountStatusTypesService;
        public IGroupAccountStatusTypesService GroupAccountStatusTypesService
        {
            get
            {
                if (null == _groupAccountStatusTypesService)
                {
                    _groupAccountStatusTypesService = _kernel.Get<IGroupAccountStatusTypesService>(_parms);
                }

                return _groupAccountStatusTypesService;
            }
        }

        private IGroupAccountTypesService _groupAccountTypesService;
        public IGroupAccountTypesService GroupAccountTypesService
        {
            get
            {
                if (null == _groupAccountTypesService)
                {
                    _groupAccountTypesService = _kernel.Get<IGroupAccountTypesService>(_parms);
                }

                return _groupAccountTypesService;
            }
        }

        private IPaymentPlanAccountFeesService _paymentPlanAccountFeesService;
        public IPaymentPlanAccountFeesService PaymentPlanAccountFeesService
        {
            get
            {
                if (null == _paymentPlanAccountFeesService)
                {
                    _paymentPlanAccountFeesService = _kernel.Get<IPaymentPlanAccountFeesService>(_parms);
                }

                return _paymentPlanAccountFeesService;
            }
        }

        private IPaymentPlanAccountsService _paymentPlanAccountsService;
        public IPaymentPlanAccountsService PaymentPlanAccountsService
        {
            get
            {
                if (null == _paymentPlanAccountsService)
                {
                    _paymentPlanAccountsService = _kernel.Get<IPaymentPlanAccountsService>(_parms);
                }

                return _paymentPlanAccountsService;
            }
        }

        private IPaymentPlanGroupAccountFeesService _paymentPlanGroupAccountFeesService;
        public IPaymentPlanGroupAccountFeesService PaymentPlanGroupAccountFeesService
        {
            get
            {
                if (null == _paymentPlanGroupAccountFeesService)
                {
                    _paymentPlanGroupAccountFeesService = _kernel.Get<IPaymentPlanGroupAccountFeesService>(_parms);
                }

                return _paymentPlanGroupAccountFeesService;
            }
        }

        private IPaymentPlanGroupAccountsService _paymentPlanGroupAccountsService;
        public IPaymentPlanGroupAccountsService PaymentPlanGroupAccountsService
        {
            get
            {
                if (null == _paymentPlanGroupAccountsService)
                {
                    _paymentPlanGroupAccountsService = _kernel.Get<IPaymentPlanGroupAccountsService>(_parms);
                }

                return _paymentPlanGroupAccountsService;
            }
        }

        private IQuestionnaireQuestionAnswerTypesService _questionnaireQuestionAnswerTypesService;
        public IQuestionnaireQuestionAnswerTypesService QuestionnaireQuestionAnswerTypesService
        {
            get
            {
                if (null == _questionnaireQuestionAnswerTypesService)
                {
                    _questionnaireQuestionAnswerTypesService = _kernel.Get<IQuestionnaireQuestionAnswerTypesService>(_parms);
                }

                return _questionnaireQuestionAnswerTypesService;
            }
        }

        private IQuestionnaireQuestionMultichoiceAnswersService _questionnaireQuestionMultichoiceAnswersService;
        public IQuestionnaireQuestionMultichoiceAnswersService QuestionnaireQuestionMultichoiceAnswersService
        {
            get
            {
                if (null == _questionnaireQuestionMultichoiceAnswersService)
                {
                    _questionnaireQuestionMultichoiceAnswersService = _kernel.Get<IQuestionnaireQuestionMultichoiceAnswersService>(_parms);
                }

                return _questionnaireQuestionMultichoiceAnswersService;
            }
        }

        private IQuestionnaireQuestionnaireQuestionLinksService _questionnaireQuestionnaireQuestionLinksService;
        public IQuestionnaireQuestionnaireQuestionLinksService QuestionnaireQuestionnaireQuestionLinksService
        {
            get
            {
                if (null == _questionnaireQuestionnaireQuestionLinksService)
                {
                    _questionnaireQuestionnaireQuestionLinksService = _kernel.Get<IQuestionnaireQuestionnaireQuestionLinksService>(_parms);
                }

                return _questionnaireQuestionnaireQuestionLinksService;
            }
        }

        private IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService;
        public IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService
        {
            get
            {
                if (null == _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService)
                {
                    _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService = _kernel.Get<IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService>(_parms);
                }

                return _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksService;
            }
        }

        private IQuestionnaireQuestionsService _questionnaireQuestionsService;
        public IQuestionnaireQuestionsService QuestionnaireQuestionsService
        {
            get
            {
                if (null == _questionnaireQuestionsService)
                {
                    _questionnaireQuestionsService = _kernel.Get<IQuestionnaireQuestionsService>(_parms);
                }

                return _questionnaireQuestionsService;
            }
        }

        private IQuestionnaireQuestionTypesService _questionnaireQuestionTypesService;
        public IQuestionnaireQuestionTypesService QuestionnaireQuestionTypesService
        {
            get
            {
                if (null == _questionnaireQuestionTypesService)
                {
                    _questionnaireQuestionTypesService = _kernel.Get<IQuestionnaireQuestionTypesService>(_parms);
                }

                return _questionnaireQuestionTypesService;
            }
        }

        private IQuestionnairesService _questionnairesService;
        public IQuestionnairesService QuestionnairesService
        {
            get
            {
                if (null == _questionnairesService)
                {
                    _questionnairesService = _kernel.Get<IQuestionnairesService>(_parms);
                }

                return _questionnairesService;
            }
        }

        private IQuestionnaireTypesService _questionnaireTypesService;
        public IQuestionnaireTypesService QuestionnaireTypesService
        {
            get
            {
                if (null == _questionnaireTypesService)
                {
                    _questionnaireTypesService = _kernel.Get<IQuestionnaireTypesService>(_parms);
                }

                return _questionnaireTypesService;
            }
        }

        private IRCAccountBalancesService _rCAccountBalancesService;
        public IRCAccountBalancesService RCAccountBalancesService
        {
            get
            {
                if (null == _rCAccountBalancesService)
                {
                    _rCAccountBalancesService = _kernel.Get<IRCAccountBalancesService>(_parms);
                }

                return _rCAccountBalancesService;
            }
        }

        private IRCAccountTransactionsService _rCAccountTransactionsService;
        public IRCAccountTransactionsService RCAccountTransactionsService
        {
            get
            {
                if (null == _rCAccountTransactionsService)
                {
                    _rCAccountTransactionsService = _kernel.Get<IRCAccountTransactionsService>(_parms);
                }

                return _rCAccountTransactionsService;
            }
        }


    }
}
