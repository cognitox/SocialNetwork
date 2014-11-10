using Social.Data.DatabaseContext;
using Social.Core.Services.Database.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Data.UnitOfWork;
using Social.Common.Helpers.Implementation;
using Social.Common.Helpers;
using Social.Common.Configuration;

namespace Social.Core.Services.Database.Implementation
{

    public class AccountsService : BaseService<Account>, Social.Core.Services.Database.IAccountsService
    {
        private IEmailHelper _emailHelper;
        public AccountsService(IUnitOfWork unitOfWork)
        {
            SetContext(unitOfWork);
            _emailHelper = new EmailHelper();
        }

        /// <summary>
        /// Unit Test Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="emailHelper"></param>
        public AccountsService(IUnitOfWork unitOfWork, IEmailHelper emailHelper)
        {
            SetContext(unitOfWork);
            _emailHelper = emailHelper;
        }

        /// <summary>
        /// Creates or updates a new or existing user in the system,
        /// Sets the account type to standard and the payment plan to free.
        /// if the user exists in the system it updates the timestamp for 
        /// the system user.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Account CreateOrUpdateFreeStandardAccount(String username)
        {
            var loweredUsername = username.ToLower();
            Account retVal = null;

            var isValidEmail = _emailHelper.IsValidEmail(username);
            if (isValidEmail)
            {
                //retrieve the account
                var accountRepository = _unitOfWork.AccountsRepository;
                var exists = accountRepository
                                   .Where(acc => acc.Email.Contains(loweredUsername))
                                   .FirstOrDefault();

                if (null == exists) //create new account
                {
                    retVal = CreateFreeStandardAccount(loweredUsername);
                }
                else
                {
                    //update the time stamp
                    exists.UpdatedDate = DateTime.UtcNow;
                    retVal = accountRepository.Update(exists);
                }
            }
            return retVal;
        }


        /// <summary>
        /// Creates a new Free Standard account from username,
        /// doesn't check if the user already exists within the system,
        /// all existance checking needs to happen before the user is created
        /// </summary>
        /// <param name="loweredUsername"></param>
        public Account CreateFreeStandardAccount(string loweredUsername)
        {
            var accountRepository = _unitOfWork.AccountsRepository;
            //account type
            var accountTypesRepository = _unitOfWork.AccountTypesRepository;
            var accountType = accountTypesRepository.Where(at => at.Type == "Standard").FirstOrDefault();
            if (null == accountType) throw new Exception("The [Standard] Account Type, doesn't exist.");

            //payment plan
            var paymentPlanAccountsRepository = _unitOfWork.PaymentPlanAccountsRepository;
            var paymentPlan = paymentPlanAccountsRepository.Where(ppa => ppa.Name == "Free").FirstOrDefault();
            if (null == paymentPlan) throw new Exception("The [Free] Payment Plan Account, doesn't exist.");

            //create a standard, free account
            var newAccount = new Account()
            {
                Email = loweredUsername,
                AccountTypeID = accountType.AccountTypeID,
                PaymentPlanAccountID = paymentPlan.PaymentPlanAccountID,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };
            var createdAccount = accountRepository.Create(newAccount);

            //create the account meta data
            var accountMetaDataRepository = _unitOfWork.AccountMetaDatasRepository;

            //account status type repository
            var accountStatusTypeRepository = _unitOfWork.AccountStatusTypesRepository;
            var accountStatusType = accountStatusTypeRepository.Where(ast => ast.Type == "Active").FirstOrDefault();
            if (null == accountStatusType) throw new Exception("The [Active] Account Status Type, doesn't exist.");


            var accountMetaData = new AccountMetaData()
            {
                AccountID = createdAccount.AccountID,
                AccountStatusTypeID = accountStatusType.AccountStatusTypeID,
                ProfileImage = ProfileConfiguration.DefaultUserImage,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            accountMetaDataRepository.Create(accountMetaData);
            createdAccount.AccountMetaDatas.Add(accountMetaData);
            return createdAccount;
        }

        /// <summary>
        /// Gets account by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Account GetAccountByEmail(string email)
        {
            var repository = _unitOfWork.AccountsRepository;
            var accounts = repository.Where(a => a.Email == email);
            return accounts.FirstOrDefault();
        }

        /// <summary>
        /// Gets account by id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Account GetAccountByID(Guid accountID)
        {
            var repository = _unitOfWork.AccountsRepository;
            var accounts = repository.Where(a => a.AccountID == accountID);
            return accounts.FirstOrDefault();
        }

    }
}