using Ninject;
using Ninject.Modules;
using Social.Data.Bindings;
using Social.Data.DatabaseContext;
using Social.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.UnitOfWork.Implementation
{
    public class UnitOfWork : IDisposable, Social.Data.UnitOfWork.IUnitOfWork
    {
        private IKernel _kernel;
        private SDBOAppContext _context;
        private Ninject.Parameters.Parameter _parms;
        public UnitOfWork()
        {
            //load in the bindings
            _kernel = new StandardKernel();
            _kernel.Load(new NinjectRepositoryBindings());
            _context = new SDBOAppContext();
            _parms = new Ninject.Parameters.ConstructorArgument("context", _context);

        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        private IAccountAccountSettingsLinksRepository _accountAccountSettingsLinksRepository;
        public IAccountAccountSettingsLinksRepository AccountAccountSettingsLinksRepository
        {
            get
            {
                if (null == _accountAccountSettingsLinksRepository)
                {
                    _accountAccountSettingsLinksRepository = _kernel.Get<IAccountAccountSettingsLinksRepository>(_parms);
                }

                return _accountAccountSettingsLinksRepository;
            }
        }

        private IAccountCommitmentLinksRepository _accountCommitmentLinksRepository;
        public IAccountCommitmentLinksRepository AccountCommitmentLinksRepository
        {
            get
            {
                if (null == _accountCommitmentLinksRepository)
                {
                    _accountCommitmentLinksRepository = _kernel.Get<IAccountCommitmentLinksRepository>(_parms);
                }

                return _accountCommitmentLinksRepository;
            }
        }

        private IAccountCommitmentLinkTypesRepository _accountCommitmentLinkTypesRepository;
        public IAccountCommitmentLinkTypesRepository AccountCommitmentLinkTypesRepository
        {
            get
            {
                if (null == _accountCommitmentLinkTypesRepository)
                {
                    _accountCommitmentLinkTypesRepository = _kernel.Get<IAccountCommitmentLinkTypesRepository>(_parms);
                }

                return _accountCommitmentLinkTypesRepository;
            }
        }

        private IAccountConfigurationsRepository _accountConfigurationsRepository;
        public IAccountConfigurationsRepository AccountConfigurationsRepository
        {
            get
            {
                if (null == _accountConfigurationsRepository)
                {
                    _accountConfigurationsRepository = _kernel.Get<IAccountConfigurationsRepository>(_parms);
                }

                return _accountConfigurationsRepository;
            }
        }

        private IAccountGroupAccountLinksRepository _accountGroupAccountLinksRepository;
        public IAccountGroupAccountLinksRepository AccountGroupAccountLinksRepository
        {
            get
            {
                if (null == _accountGroupAccountLinksRepository)
                {
                    _accountGroupAccountLinksRepository = _kernel.Get<IAccountGroupAccountLinksRepository>(_parms);
                }

                return _accountGroupAccountLinksRepository;
            }
        }

        private IAccountMetaDatasRepository _accountMetaDatasRepository;
        public IAccountMetaDatasRepository AccountMetaDatasRepository
        {
            get
            {
                if (null == _accountMetaDatasRepository)
                {
                    _accountMetaDatasRepository = _kernel.Get<IAccountMetaDatasRepository>(_parms);
                }

                return _accountMetaDatasRepository;
            }
        }

        private IAccountRolesRepository _accountRolesRepository;
        public IAccountRolesRepository AccountRolesRepository
        {
            get
            {
                if (null == _accountRolesRepository)
                {
                    _accountRolesRepository = _kernel.Get<IAccountRolesRepository>(_parms);
                }

                return _accountRolesRepository;
            }
        }

        private IAccountSettingsAccountSettingsMultichoiceAnswerLinksRepository _accountSettingsAccountSettingsMultichoiceAnswerLinksRepository;
        public IAccountSettingsAccountSettingsMultichoiceAnswerLinksRepository AccountSettingsAccountSettingsMultichoiceAnswerLinksRepository
        {
            get
            {
                if (null == _accountSettingsAccountSettingsMultichoiceAnswerLinksRepository)
                {
                    _accountSettingsAccountSettingsMultichoiceAnswerLinksRepository = _kernel.Get<IAccountSettingsAccountSettingsMultichoiceAnswerLinksRepository>(_parms);
                }

                return _accountSettingsAccountSettingsMultichoiceAnswerLinksRepository;
            }
        }

        private IAccountSettingsMultichoiceAnswersRepository _accountSettingsMultichoiceAnswersRepository;
        public IAccountSettingsMultichoiceAnswersRepository AccountSettingsMultichoiceAnswersRepository
        {
            get
            {
                if (null == _accountSettingsMultichoiceAnswersRepository)
                {
                    _accountSettingsMultichoiceAnswersRepository = _kernel.Get<IAccountSettingsMultichoiceAnswersRepository>(_parms);
                }

                return _accountSettingsMultichoiceAnswersRepository;
            }
        }

        private IAccountSettingsRepository _accountSettingsRepository;
        public IAccountSettingsRepository AccountSettingsRepository
        {
            get
            {
                if (null == _accountSettingsRepository)
                {
                    _accountSettingsRepository = _kernel.Get<IAccountSettingsRepository>(_parms);
                }

                return _accountSettingsRepository;
            }
        }

        private IAccountSettingsTypesRepository _accountSettingsTypesRepository;
        public IAccountSettingsTypesRepository AccountSettingsTypesRepository
        {
            get
            {
                if (null == _accountSettingsTypesRepository)
                {
                    _accountSettingsTypesRepository = _kernel.Get<IAccountSettingsTypesRepository>(_parms);
                }

                return _accountSettingsTypesRepository;
            }
        }

        private IAccountsRepository _accountsRepository;
        public IAccountsRepository AccountsRepository
        {
            get
            {
                if (null == _accountsRepository)
                {
                    _accountsRepository = _kernel.Get<IAccountsRepository>(_parms);
                }

                return _accountsRepository;
            }
        }

        private IAccountStatusTypesRepository _accountStatusTypesRepository;
        public IAccountStatusTypesRepository AccountStatusTypesRepository
        {
            get
            {
                if (null == _accountStatusTypesRepository)
                {
                    _accountStatusTypesRepository = _kernel.Get<IAccountStatusTypesRepository>(_parms);
                }

                return _accountStatusTypesRepository;
            }
        }

        private IAccountTypesRepository _accountTypesRepository;
        public IAccountTypesRepository AccountTypesRepository
        {
            get
            {
                if (null == _accountTypesRepository)
                {
                    _accountTypesRepository = _kernel.Get<IAccountTypesRepository>(_parms);
                }

                return _accountTypesRepository;
            }
        }

        private ICommitmentGroupsRepository _commitmentGroupsRepository;
        public ICommitmentGroupsRepository CommitmentGroupsRepository
        {
            get
            {
                if (null == _commitmentGroupsRepository)
                {
                    _commitmentGroupsRepository = _kernel.Get<ICommitmentGroupsRepository>(_parms);
                }

                return _commitmentGroupsRepository;
            }
        }

        private ICommitmentGroupStatusTypesRepository _commitmentGroupStatusTypesRepository;
        public ICommitmentGroupStatusTypesRepository CommitmentGroupStatusTypesRepository
        {
            get
            {
                if (null == _commitmentGroupStatusTypesRepository)
                {
                    _commitmentGroupStatusTypesRepository = _kernel.Get<ICommitmentGroupStatusTypesRepository>(_parms);
                }

                return _commitmentGroupStatusTypesRepository;
            }
        }

        private ICommitmentNotesRepository _commitmentNotesRepository;
        public ICommitmentNotesRepository CommitmentNotesRepository
        {
            get
            {
                if (null == _commitmentNotesRepository)
                {
                    _commitmentNotesRepository = _kernel.Get<ICommitmentNotesRepository>(_parms);
                }

                return _commitmentNotesRepository;
            }
        }

        private ICommitmentNoteTypesRepository _commitmentNoteTypesRepository;
        public ICommitmentNoteTypesRepository CommitmentNoteTypesRepository
        {
            get
            {
                if (null == _commitmentNoteTypesRepository)
                {
                    _commitmentNoteTypesRepository = _kernel.Get<ICommitmentNoteTypesRepository>(_parms);
                }

                return _commitmentNoteTypesRepository;
            }
        }

        private ICommitmentQuestionnaireLinksRepository _commitmentQuestionnaireLinksRepository;
        public ICommitmentQuestionnaireLinksRepository CommitmentQuestionnaireLinksRepository
        {
            get
            {
                if (null == _commitmentQuestionnaireLinksRepository)
                {
                    _commitmentQuestionnaireLinksRepository = _kernel.Get<ICommitmentQuestionnaireLinksRepository>(_parms);
                }

                return _commitmentQuestionnaireLinksRepository;
            }
        }

        private ICommitmentQuestionnaireLinkTypesRepository _commitmentQuestionnaireLinkTypesRepository;
        public ICommitmentQuestionnaireLinkTypesRepository CommitmentQuestionnaireLinkTypesRepository
        {
            get
            {
                if (null == _commitmentQuestionnaireLinkTypesRepository)
                {
                    _commitmentQuestionnaireLinkTypesRepository = _kernel.Get<ICommitmentQuestionnaireLinkTypesRepository>(_parms);
                }

                return _commitmentQuestionnaireLinkTypesRepository;
            }
        }

        private ICommitmentsRepository _commitmentsRepository;
        public ICommitmentsRepository CommitmentsRepository
        {
            get
            {
                if (null == _commitmentsRepository)
                {
                    _commitmentsRepository = _kernel.Get<ICommitmentsRepository>(_parms);
                }

                return _commitmentsRepository;
            }
        }

        private ICommitmentStatusTypesRepository _commitmentStatusTypesRepository;
        public ICommitmentStatusTypesRepository CommitmentStatusTypesRepository
        {
            get
            {
                if (null == _commitmentStatusTypesRepository)
                {
                    _commitmentStatusTypesRepository = _kernel.Get<ICommitmentStatusTypesRepository>(_parms);
                }

                return _commitmentStatusTypesRepository;
            }
        }

        private ICommitmentTypesRepository _commitmentTypesRepository;
        public ICommitmentTypesRepository CommitmentTypesRepository
        {
            get
            {
                if (null == _commitmentTypesRepository)
                {
                    _commitmentTypesRepository = _kernel.Get<ICommitmentTypesRepository>(_parms);
                }

                return _commitmentTypesRepository;
            }
        }

        private ICommitmentTypeSubTypesRepository _commitmentTypeSubTypesRepository;
        public ICommitmentTypeSubTypesRepository CommitmentTypeSubTypesRepository
        {
            get
            {
                if (null == _commitmentTypeSubTypesRepository)
                {
                    _commitmentTypeSubTypesRepository = _kernel.Get<ICommitmentTypeSubTypesRepository>(_parms);
                }

                return _commitmentTypeSubTypesRepository;
            }
        }

        private IGroupAccountConfigurationsRepository _groupAccountConfigurationsRepository;
        public IGroupAccountConfigurationsRepository GroupAccountConfigurationsRepository
        {
            get
            {
                if (null == _groupAccountConfigurationsRepository)
                {
                    _groupAccountConfigurationsRepository = _kernel.Get<IGroupAccountConfigurationsRepository>(_parms);
                }

                return _groupAccountConfigurationsRepository;
            }
        }

        private IGroupAccountGroupAccountSettingsLinksRepository _groupAccountGroupAccountSettingsLinksRepository;
        public IGroupAccountGroupAccountSettingsLinksRepository GroupAccountGroupAccountSettingsLinksRepository
        {
            get
            {
                if (null == _groupAccountGroupAccountSettingsLinksRepository)
                {
                    _groupAccountGroupAccountSettingsLinksRepository = _kernel.Get<IGroupAccountGroupAccountSettingsLinksRepository>(_parms);
                }

                return _groupAccountGroupAccountSettingsLinksRepository;
            }
        }

        private IGroupAccountMetaDatasRepository _groupAccountMetaDatasRepository;
        public IGroupAccountMetaDatasRepository GroupAccountMetaDatasRepository
        {
            get
            {
                if (null == _groupAccountMetaDatasRepository)
                {
                    _groupAccountMetaDatasRepository = _kernel.Get<IGroupAccountMetaDatasRepository>(_parms);
                }

                return _groupAccountMetaDatasRepository;
            }
        }

        private IGroupAccountRolesRepository _groupAccountRolesRepository;
        public IGroupAccountRolesRepository GroupAccountRolesRepository
        {
            get
            {
                if (null == _groupAccountRolesRepository)
                {
                    _groupAccountRolesRepository = _kernel.Get<IGroupAccountRolesRepository>(_parms);
                }

                return _groupAccountRolesRepository;
            }
        }

        private IGroupAccountSettingsRepository _groupAccountSettingsRepository;
        public IGroupAccountSettingsRepository GroupAccountSettingsRepository
        {
            get
            {
                if (null == _groupAccountSettingsRepository)
                {
                    _groupAccountSettingsRepository = _kernel.Get<IGroupAccountSettingsRepository>(_parms);
                }

                return _groupAccountSettingsRepository;
            }
        }

        private IGroupAccountSettingsTypesRepository _groupAccountSettingsTypesRepository;
        public IGroupAccountSettingsTypesRepository GroupAccountSettingsTypesRepository
        {
            get
            {
                if (null == _groupAccountSettingsTypesRepository)
                {
                    _groupAccountSettingsTypesRepository = _kernel.Get<IGroupAccountSettingsTypesRepository>(_parms);
                }

                return _groupAccountSettingsTypesRepository;
            }
        }

        private IGroupAccountsRepository _groupAccountsRepository;
        public IGroupAccountsRepository GroupAccountsRepository
        {
            get
            {
                if (null == _groupAccountsRepository)
                {
                    _groupAccountsRepository = _kernel.Get<IGroupAccountsRepository>(_parms);
                }

                return _groupAccountsRepository;
            }
        }

        private IGroupAccountStatusTypesRepository _groupAccountStatusTypesRepository;
        public IGroupAccountStatusTypesRepository GroupAccountStatusTypesRepository
        {
            get
            {
                if (null == _groupAccountStatusTypesRepository)
                {
                    _groupAccountStatusTypesRepository = _kernel.Get<IGroupAccountStatusTypesRepository>(_parms);
                }

                return _groupAccountStatusTypesRepository;
            }
        }

        private IGroupAccountTypesRepository _groupAccountTypesRepository;
        public IGroupAccountTypesRepository GroupAccountTypesRepository
        {
            get
            {
                if (null == _groupAccountTypesRepository)
                {
                    _groupAccountTypesRepository = _kernel.Get<IGroupAccountTypesRepository>(_parms);
                }

                return _groupAccountTypesRepository;
            }
        }

        private IPaymentPlanAccountFeesRepository _paymentPlanAccountFeesRepository;
        public IPaymentPlanAccountFeesRepository PaymentPlanAccountFeesRepository
        {
            get
            {
                if (null == _paymentPlanAccountFeesRepository)
                {
                    _paymentPlanAccountFeesRepository = _kernel.Get<IPaymentPlanAccountFeesRepository>(_parms);
                }

                return _paymentPlanAccountFeesRepository;
            }
        }

        private IPaymentPlanAccountsRepository _paymentPlanAccountsRepository;
        public IPaymentPlanAccountsRepository PaymentPlanAccountsRepository
        {
            get
            {
                if (null == _paymentPlanAccountsRepository)
                {
                    _paymentPlanAccountsRepository = _kernel.Get<IPaymentPlanAccountsRepository>(_parms);
                }

                return _paymentPlanAccountsRepository;
            }
        }

        private IPaymentPlanGroupAccountFeesRepository _paymentPlanGroupAccountFeesRepository;
        public IPaymentPlanGroupAccountFeesRepository PaymentPlanGroupAccountFeesRepository
        {
            get
            {
                if (null == _paymentPlanGroupAccountFeesRepository)
                {
                    _paymentPlanGroupAccountFeesRepository = _kernel.Get<IPaymentPlanGroupAccountFeesRepository>(_parms);
                }

                return _paymentPlanGroupAccountFeesRepository;
            }
        }

        private IPaymentPlanGroupAccountsRepository _paymentPlanGroupAccountsRepository;
        public IPaymentPlanGroupAccountsRepository PaymentPlanGroupAccountsRepository
        {
            get
            {
                if (null == _paymentPlanGroupAccountsRepository)
                {
                    _paymentPlanGroupAccountsRepository = _kernel.Get<IPaymentPlanGroupAccountsRepository>(_parms);
                }

                return _paymentPlanGroupAccountsRepository;
            }
        }

        private IQuestionnaireQuestionAnswerTypesRepository _questionnaireQuestionAnswerTypesRepository;
        public IQuestionnaireQuestionAnswerTypesRepository QuestionnaireQuestionAnswerTypesRepository
        {
            get
            {
                if (null == _questionnaireQuestionAnswerTypesRepository)
                {
                    _questionnaireQuestionAnswerTypesRepository = _kernel.Get<IQuestionnaireQuestionAnswerTypesRepository>(_parms);
                }

                return _questionnaireQuestionAnswerTypesRepository;
            }
        }

        private IQuestionnaireQuestionMultichoiceAnswersRepository _questionnaireQuestionMultichoiceAnswersRepository;
        public IQuestionnaireQuestionMultichoiceAnswersRepository QuestionnaireQuestionMultichoiceAnswersRepository
        {
            get
            {
                if (null == _questionnaireQuestionMultichoiceAnswersRepository)
                {
                    _questionnaireQuestionMultichoiceAnswersRepository = _kernel.Get<IQuestionnaireQuestionMultichoiceAnswersRepository>(_parms);
                }

                return _questionnaireQuestionMultichoiceAnswersRepository;
            }
        }

        private IQuestionnaireQuestionnaireQuestionLinksRepository _questionnaireQuestionnaireQuestionLinksRepository;
        public IQuestionnaireQuestionnaireQuestionLinksRepository QuestionnaireQuestionnaireQuestionLinksRepository
        {
            get
            {
                if (null == _questionnaireQuestionnaireQuestionLinksRepository)
                {
                    _questionnaireQuestionnaireQuestionLinksRepository = _kernel.Get<IQuestionnaireQuestionnaireQuestionLinksRepository>(_parms);
                }

                return _questionnaireQuestionnaireQuestionLinksRepository;
            }
        }

        private IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository;
        public IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository QuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository
        {
            get
            {
                if (null == _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository)
                {
                    _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository = _kernel.Get<IQuestionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository>(_parms);
                }

                return _questionnaireQuestionQuestionnaireQuestionMultichoiceAnswerLinksRepository;
            }
        }

        private IQuestionnaireQuestionsRepository _questionnaireQuestionsRepository;
        public IQuestionnaireQuestionsRepository QuestionnaireQuestionsRepository
        {
            get
            {
                if (null == _questionnaireQuestionsRepository)
                {
                    _questionnaireQuestionsRepository = _kernel.Get<IQuestionnaireQuestionsRepository>(_parms);
                }

                return _questionnaireQuestionsRepository;
            }
        }

        private IQuestionnaireQuestionTypesRepository _questionnaireQuestionTypesRepository;
        public IQuestionnaireQuestionTypesRepository QuestionnaireQuestionTypesRepository
        {
            get
            {
                if (null == _questionnaireQuestionTypesRepository)
                {
                    _questionnaireQuestionTypesRepository = _kernel.Get<IQuestionnaireQuestionTypesRepository>(_parms);
                }

                return _questionnaireQuestionTypesRepository;
            }
        }

        private IQuestionnairesRepository _questionnairesRepository;
        public IQuestionnairesRepository QuestionnairesRepository
        {
            get
            {
                if (null == _questionnairesRepository)
                {
                    _questionnairesRepository = _kernel.Get<IQuestionnairesRepository>(_parms);
                }

                return _questionnairesRepository;
            }
        }

        private IQuestionnaireTypesRepository _questionnaireTypesRepository;
        public IQuestionnaireTypesRepository QuestionnaireTypesRepository
        {
            get
            {
                if (null == _questionnaireTypesRepository)
                {
                    _questionnaireTypesRepository = _kernel.Get<IQuestionnaireTypesRepository>(_parms);
                }

                return _questionnaireTypesRepository;
            }
        }

        private IRCAccountBalancesRepository _rCAccountBalancesRepository;
        public IRCAccountBalancesRepository RCAccountBalancesRepository
        {
            get
            {
                if (null == _rCAccountBalancesRepository)
                {
                    _rCAccountBalancesRepository = _kernel.Get<IRCAccountBalancesRepository>(_parms);
                }

                return _rCAccountBalancesRepository;
            }
        }

        private IRCAccountTransactionsRepository _rCAccountTransactionsRepository;
        public IRCAccountTransactionsRepository RCAccountTransactionsRepository
        {
            get
            {
                if (null == _rCAccountTransactionsRepository)
                {
                    _rCAccountTransactionsRepository = _kernel.Get<IRCAccountTransactionsRepository>(_parms);
                }

                return _rCAccountTransactionsRepository;
            }
        }

    }
}
