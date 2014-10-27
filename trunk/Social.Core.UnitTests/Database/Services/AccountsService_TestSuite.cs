using NUnit.Framework;
using Social.Common.Helpers;
using Social.Core.Services.Database.Implementation;
using Social.Data.DatabaseContext;
using Social.Data.Repositories;
using Social.Data.UnitOfWork;
using Social.Data.UnitOfWork.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.UnitTests.Database.Services
{
    [TestFixture]
    class AccountsService_TestSuite
    {
        private string _integrationUser = "test_user@gmail.com";
        private string _integrationUser1 = "test_user_1@gmail.com";

        #region Setup/Teardown

        [TestFixtureSetUp]
        public void Setup()
        {

        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            var unitOfWork = new UnitOfWork();
            var repository = unitOfWork.AccountsRepository;
            var integrationUser = repository.Where(a => a.Email == _integrationUser);
            var integrationUser1 = repository.Where(a => a.Email == _integrationUser1);

            repository.HardDelete(integrationUser);
            repository.HardDelete(integrationUser1);
        }

        #endregion

        #region CreateOrUpdateFreeStandardAccount

        //integration testing

        [Test]
        public void CreateOrUpdateFreeStandardAccount_CreateAccount_Integration_Test()
        {
            //arrange
            var unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            var service = unitOfService.AccountsService;
            //act
            var result = service.CreateOrUpdateFreeStandardAccount(_integrationUser);
            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void CreateOrUpdateFreeStandardAccount_CreateThenUpdateAccount_Integration_Test()
        {
            //arrange
            var unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            var service = unitOfService.AccountsService;

            //act

            //create user
            var result = service.CreateOrUpdateFreeStandardAccount(_integrationUser1);

            //update user
            var result2 = service.CreateOrUpdateFreeStandardAccount(_integrationUser1);

            //assert
            Assert.NotNull(result);
            Assert.NotNull(result2);

        }

        //standard testing

        [Test]
        public void CreateOrUpdateFreeStandardAccount_InvalidEmailAddress_Test()
        {
            //arrange
            //mock email helper
            var mockEmailHelper = new Moq.Mock<IEmailHelper>();
            mockEmailHelper.Setup(a => a.IsValidEmail(Moq.It.IsAny<String>()))
                .Returns(false);

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            var service = new AccountsService(mockUnitOfWork.Object, mockEmailHelper.Object);

            //act

            //create user
            var result = service.CreateOrUpdateFreeStandardAccount("test_user_1@gmail.com");

            //assert
            Assert.IsNull(result);
            mockEmailHelper.VerifyAll();
        }

        [Test]
        public void CreateOrUpdateFreeStandardAccount_AccountExists_UpdateTimestamp_Test()
        {

            //arrange

            //mock email helper
            var mockEmailHelper = new Moq.Mock<IEmailHelper>();
            mockEmailHelper.Setup(a => a.IsValidEmail(Moq.It.IsAny<String>()))
                .Returns(true);

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup( a => a.Where(Moq.It.IsAny<Func<Account,bool>>())).Returns(()=>{
                var accounts = new List<Account>();
                accounts.Add(new Account(){
                    Email = "test@test.com"
                });
                return accounts;
            });

            //update timestamp
            mockAccountsRepository.Setup( a => a.Update(Moq.It.IsAny<Account>())).Returns(new Account());

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            
            var service = new AccountsService(mockUnitOfWork.Object, mockEmailHelper.Object);
            //act
            var result = service.CreateOrUpdateFreeStandardAccount("test_user_1@gmail.com");

            //assert
            Assert.NotNull(result);

            mockEmailHelper.VerifyAll();
            mockAccountsRepository.VerifyAll();
            mockUnitOfWork.VerifyAll();
        }

        [Test]
        public void CreateOrUpdateFreeStandardAccount_CreateAccount_Test()
        {

            //arrange

            //mock email helper
            var mockEmailHelper = new Moq.Mock<IEmailHelper>();
            mockEmailHelper.Setup(a => a.IsValidEmail(Moq.It.IsAny<String>()))
                .Returns(true);

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<Account, bool>>())).Returns(new List<Account>());
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account());

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(() =>
            {
                var accounts = new List<AccountType>();
                accounts.Add(new AccountType()
                {
                    AccountTypeID = Guid.NewGuid(),
                    Type = "Standard"
                });
                return accounts;
            });

            //mock account payment plan account repository
            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(() =>
            {
                var accounts = new List<PaymentPlanAccount>();
                accounts.Add(new PaymentPlanAccount()
                {
                    PaymentPlanAccountID = Guid.NewGuid(),
                    Name = "Free"
                });
                return accounts;
            });

            //mock account status type repository
            var mockAccountStatusTypeRepository = new Moq.Mock<IAccountStatusTypesRepository>();
            mockAccountStatusTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountStatusType, bool>>())).Returns(() =>
            {
                var accountStatusTypes = new List<AccountStatusType>();
                accountStatusTypes.Add(new AccountStatusType()
                {
                    AccountStatusTypeID = Guid.NewGuid(),
                    Type = "Active"
                });
                return accountStatusTypes;
            });

            //mock account meta data repository
            var mockAccountMetaDataRepository = new Moq.Mock<IAccountMetaDatasRepository>();
            mockAccountMetaDataRepository.Setup(a => a.Create(Moq.It.IsAny<AccountMetaData>())).Returns(new AccountMetaData());

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountMetaDatasRepository).Returns(mockAccountMetaDataRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountStatusTypesRepository).Returns(mockAccountStatusTypeRepository.Object);

            //service
            var service = new AccountsService(mockUnitOfWork.Object, mockEmailHelper.Object);

            //act
            var result = service.CreateOrUpdateFreeStandardAccount("test_user_1@gmail.com");

            //assert
            Assert.NotNull(result);
            mockPaymentPlanAccountsRepository.VerifyAll();
            mockAccountsTypeRepository.VerifyAll();
            mockAccountsRepository.VerifyAll();
            mockEmailHelper.VerifyAll();
            mockAccountMetaDataRepository.VerifyAll();
            mockAccountStatusTypeRepository.VerifyAll();

        }

        //robustness testing

        [Test]
        public void CreateOrUpdateFreeStandardAccount_AccountTypeRepository_null_Test()
        {

            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock email helper
            var mockEmailHelper = new Moq.Mock<IEmailHelper>();
            mockEmailHelper.Setup(a => a.IsValidEmail(Moq.It.IsAny<String>()))
                .Returns(true);

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<Account, bool>>())).Returns(new List<Account>());
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(new List<AccountType>());

            //mock account payment plan account repository
            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(() =>
            {
                var accounts = new List<PaymentPlanAccount>();
                accounts.Add(new PaymentPlanAccount()
                {
                    PaymentPlanAccountID = Guid.NewGuid(),
                    Name = "Free"
                });
                return accounts;
            });

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);

            //service
            var service = new AccountsService(mockUnitOfWork.Object, mockEmailHelper.Object);

            String ErrorText = String.Empty;
            //act
            try
            {
                service.CreateOrUpdateFreeStandardAccount("test_user_1@gmail.com");
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
            }

            //assert
            Assert.AreEqual(ErrorText, "The [Standard] Account Type, doesn't exist.");
        }

        [Test]
        public void CreateOrUpdateFreeStandardAccount_PaymentPlanAccountRepository_null_Test()
        {

            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock email helper
            var mockEmailHelper = new Moq.Mock<IEmailHelper>();
            mockEmailHelper.Setup(a => a.IsValidEmail(Moq.It.IsAny<String>()))
                .Returns(true);

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<Account, bool>>())).Returns(new List<Account>());
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(() =>
            {

                var accounts = new List<AccountType>();
                accounts.Add(new AccountType()
                {
                    AccountTypeID = Guid.NewGuid(),
                    Type = "Standard"
                });
                return accounts;
            });

            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(new List<PaymentPlanAccount>());

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);

            //service
            var service = new AccountsService(mockUnitOfWork.Object, mockEmailHelper.Object);

            String ErrorText = String.Empty;

            //act
            try
            {
                service.CreateOrUpdateFreeStandardAccount("test_user_1@gmail.com");
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
            }

            //assert
            Assert.AreEqual(ErrorText, "The [Free] Payment Plan Account, doesn't exist.");//"The [Standard] Account Type, doesn't exist."
        }


        [Test]
        public void CreateOrUpdateFreeStandardAccount_AccountStatusTypeRepository_null_Test()
        {

            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock email helper
            var mockEmailHelper = new Moq.Mock<IEmailHelper>();
            mockEmailHelper.Setup(a => a.IsValidEmail(Moq.It.IsAny<String>()))
                .Returns(true);

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<Account, bool>>())).Returns(new List<Account>());
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(() =>
            {

                var accounts = new List<AccountType>();
                accounts.Add(new AccountType()
                {
                    AccountTypeID = Guid.NewGuid(),
                    Type = "Standard"
                });
                return accounts;
            });

            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(() =>
            {
                var payments = new List<PaymentPlanAccount>();
                payments.Add(new PaymentPlanAccount()
                {
                    PaymentPlanAccountID = Guid.NewGuid(),
                    Name = "Free"
                });
                return payments;
            });
            //mock account status type repository
            var mockAccountStatusTypeRepository = new Moq.Mock<IAccountStatusTypesRepository>();
            mockAccountStatusTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountStatusType, bool>>())).Returns(new List<AccountStatusType>());


            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountStatusTypesRepository).Returns(mockAccountStatusTypeRepository.Object);

            //service
            var service = new AccountsService(mockUnitOfWork.Object, mockEmailHelper.Object);

            String ErrorText = String.Empty;

            //act
            try
            {
                service.CreateOrUpdateFreeStandardAccount("test_user_1@gmail.com");
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
            }

            //assert
            Assert.AreEqual(ErrorText, "The [Active] Account Status Type, doesn't exist.");
        }


        #endregion

        #region CreateFreeStandardAccount

        //integration testing

        [Test]
        public void CreateFreeStandardAccount_CreateAccount_Integration_Test()
        {
            //arrange
            var unitOfService = new Social.Core.UnitOfService.Implementation.UnitOfService();
            var service = unitOfService.AccountsService;
            //act
            var result = service.CreateFreeStandardAccount(_integrationUser);
            //assert
            Assert.NotNull(result);
        }

        // standard testing

        [Test]
        public void CreateFreeStandardAccount_CreateAccount_Test()
        {

            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            Func<AccountType, bool> actualAccountsTypeExpression = null;
            Func<AccountType, bool> expectedAccountsTypeExpression = at => at.Type == "Standard";

            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(() =>
            {

                var accounts = new List<AccountType>();
                accounts.Add(new AccountType()
                {
                    AccountTypeID = Guid.NewGuid(),
                    Type = "Standard"
                });
                return accounts;
            }).Callback((Func<AccountType, bool> x) => actualAccountsTypeExpression = x);

            //mock account payment plan account repository
            Func<PaymentPlanAccount, bool> actualPaymentPlanAccountsExpression = null;
            Func<PaymentPlanAccount, bool> expectedPaymentPlanAccountsExpression = ppa => ppa.Name == "Free";

            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(() =>
            {
                var accounts = new List<PaymentPlanAccount>();
                accounts.Add(new PaymentPlanAccount()
                {
                    PaymentPlanAccountID = Guid.NewGuid(),
                    Name = "Free"
                });
                return accounts;
            }).Callback((Func<PaymentPlanAccount, bool> x) => actualPaymentPlanAccountsExpression = x);

            

            //mock account status type repository
            Func<AccountStatusType, bool> actualAccountStatusTypeExpression = null;
            Func<AccountStatusType, bool> expectedAccountStatusTypeExpression = ast => ast.Type == "Active";

            var mockAccountStatusTypeRepository = new Moq.Mock<IAccountStatusTypesRepository>();
            mockAccountStatusTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountStatusType, bool>>())).Returns(() =>
            {
                var accounts = new List<AccountStatusType>();
                accounts.Add(new AccountStatusType()
                {
                    AccountStatusTypeID = Guid.NewGuid(),
                    Type = "Active"
                });
                return accounts;
            }).Callback((Func<AccountStatusType, bool> x) => actualAccountStatusTypeExpression = x);

            //mock account meta data repository
            var mockAccountMetaDataRepository = new Moq.Mock<IAccountMetaDatasRepository>();
            mockAccountMetaDataRepository.Setup(a => a.Create(Moq.It.IsAny<AccountMetaData>())).Returns(new AccountMetaData());

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountMetaDatasRepository).Returns(mockAccountMetaDataRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountStatusTypesRepository).Returns(mockAccountStatusTypeRepository.Object);

            //service
            var service = new AccountsService(mockUnitOfWork.Object);

            //act
            var result = service.CreateFreeStandardAccount("test_user_1@gmail.com");

            //assert
            Assert.AreEqual(result.AccountID, newAccountGuid);
            mockPaymentPlanAccountsRepository.VerifyAll();
            mockAccountsTypeRepository.VerifyAll();
            mockAccountsRepository.VerifyAll();
            mockAccountMetaDataRepository.VerifyAll();
            mockAccountStatusTypeRepository.VerifyAll();

            //make sure that the input of the Func<T,bool> are the expected inputs
            Assert.AreEqual(expectedAccountsTypeExpression.ToString(), actualAccountsTypeExpression.ToString());
            Assert.AreEqual(expectedPaymentPlanAccountsExpression.ToString(), actualPaymentPlanAccountsExpression.ToString());
            Assert.AreEqual(expectedAccountStatusTypeExpression.ToString(), actualAccountStatusTypeExpression.ToString());

        }

        //robustness testing

        [Test]
        public void CreateFreeStandardAccount_AccountTypeRepository_null_Test()
        {
            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(new List<AccountType>());

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            
            //service
            var service = new AccountsService(mockUnitOfWork.Object);

            String ErrorText = String.Empty;
            //act
            try
            {
                service.CreateFreeStandardAccount("test_user_1@gmail.com");
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
            }

            //assert
            Assert.AreEqual(ErrorText, "The [Standard] Account Type, doesn't exist.");
        }

        [Test]
        public void CreateFreeStandardAccount_PaymentPlanAccountRepository_null_Test()
        {

            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(() =>
            {
                var accounts = new List<AccountType>();
                accounts.Add(new AccountType()
                {
                    AccountTypeID = Guid.NewGuid(),
                    Type = "Standard"
                });
                return accounts;
            });

            //mock account payment plan account repository
            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(new List<PaymentPlanAccount>());

            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);
            
            //service
            var service = new AccountsService(mockUnitOfWork.Object);

            String ErrorText = String.Empty;

            //act
            try
            {
                service.CreateFreeStandardAccount("test_user_1@gmail.com");
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
            }

            //assert
            Assert.AreEqual(ErrorText, "The [Free] Payment Plan Account, doesn't exist.");//"The [Standard] Account Type, doesn't exist."
        }

        [Test]
        public void CreateFreeStandardAccount_AccountStatusTypeRepository_null_Test()
        {

            //arrange
            var newAccountGuid = Guid.NewGuid();

            //mock account repository
            var mockAccountsRepository = new Moq.Mock<IAccountsRepository>();
            mockAccountsRepository.Setup(a => a.Create(Moq.It.IsAny<Account>())).Returns(new Account()
            {
                AccountID = newAccountGuid
            });

            //mock account type repository
            var mockAccountsTypeRepository = new Moq.Mock<IAccountTypesRepository>();
            mockAccountsTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountType, bool>>())).Returns(() =>
            {

                var accounts = new List<AccountType>();
                accounts.Add(new AccountType()
                {
                    AccountTypeID = Guid.NewGuid(),
                    Type = "Standard"
                });
                return accounts;
            });

            //mock account payment plan account repository
            var mockPaymentPlanAccountsRepository = new Moq.Mock<IPaymentPlanAccountsRepository>();
            mockPaymentPlanAccountsRepository.Setup(a => a.Where(Moq.It.IsAny<Func<PaymentPlanAccount, bool>>())).Returns(() =>
            {
                var accounts = new List<PaymentPlanAccount>();
                accounts.Add(new PaymentPlanAccount()
                {
                    PaymentPlanAccountID = Guid.NewGuid(),
                    Name = "Free"
                });
                return accounts;
            });


            //mock account status type repository
            var mockAccountStatusTypeRepository = new Moq.Mock<IAccountStatusTypesRepository>();
            mockAccountStatusTypeRepository.Setup(a => a.Where(Moq.It.IsAny<Func<AccountStatusType, bool>>())).Returns(new List<AccountStatusType>());


            //moq unit of work
            var mockUnitOfWork = new Moq.Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(a => a.AccountsRepository).Returns(mockAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountTypesRepository).Returns(mockAccountsTypeRepository.Object);
            mockUnitOfWork.Setup(a => a.PaymentPlanAccountsRepository).Returns(mockPaymentPlanAccountsRepository.Object);
            mockUnitOfWork.Setup(a => a.AccountStatusTypesRepository).Returns(mockAccountStatusTypeRepository.Object);

            //service
            var service = new AccountsService(mockUnitOfWork.Object);

            String ErrorText = String.Empty;

            //act
            try
            {
                service.CreateFreeStandardAccount("test_user_1@gmail.com");
            }
            catch (Exception e)
            {
                ErrorText = e.Message;
            }

            //assert
            Assert.AreEqual(ErrorText, "The [Active] Account Status Type, doesn't exist.");
        }

        #endregion

    }
}
