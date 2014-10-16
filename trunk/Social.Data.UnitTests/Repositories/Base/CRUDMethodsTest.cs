using NUnit.Framework;
using Social.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.Data.Repositories.Base.Implementation;
using Social.Data.UnitTests.TESTHELPERS;

namespace Social.Data.UnitTests.Repositories.Base
{
    [TestFixture]
    public class CRUDMethodsTest
    {

        [Test]
        public void GenericMethodsTest()
        {
            var manager = new AccountEntityManager();

            SDBOAppContext context = new SDBOAppContext();

            var accountRepo = new CRUDMethods<Account, SDBOAppContext>(context);
            var accountTypeRepo = new CRUDMethods<AccountType, SDBOAppContext>(context);
            var accountPaymentPlanRepo = new CRUDMethods<PaymentPlanAccount, SDBOAppContext>(context);

            var accounts = accountRepo.ReadAll();
            var accountTypes = accountTypeRepo.ReadAll();
            var paymentPlans = accountPaymentPlanRepo.ReadAll();

            var mockAccount = manager.MakeAccount();
            mockAccount.AccountTypeID = accountTypes.First().AccountTypeID;
            mockAccount.PaymentPlanAccountID = paymentPlans.First().PaymentPlanAccountID;

            var createAccount = accountRepo.Create(mockAccount);

            //make sure this updates
            createAccount.Email = @"CREATE OR UPDATE";
            var createOrUpdateAccount = accountRepo.CreateOrUpdate(createAccount);

            //make sure this creates
            var mockAccount2 = manager.MakeAccount();
            mockAccount2.AccountTypeID = accountTypes.First().AccountTypeID;
            mockAccount2.PaymentPlanAccountID = paymentPlans.First().PaymentPlanAccountID;

            var createOrUpdateAccount2 = accountRepo.CreateOrUpdate(mockAccount2);

            //test create list
            var modelByID = accountRepo.Read(createOrUpdateAccount.AccountID);
            var readByModel = accountRepo.Read(modelByID);

            //test read all
            var accounts2 = accountRepo.ReadAll();
            
            //var updateAllAccounts = accountRepo.Update(accounts2);
            //var updateFirstAccount = accountRepo.Update(accounts2.First());

            accountRepo.SoftDelete(modelByID);
            accountRepo.HardDelete(mockAccount2);

            var systemAccountEmails = new List<String>()
                { 
                  @"master@relsocial.com",
                  @"administration@relsocial.com",
                  @"service@relsocial.com"
                };

            accountRepo.HardDelete(accounts2.Where(a => !systemAccountEmails.Contains(a.Email)).ToList());

            Assert.NotNull(accounts);
            Assert.NotNull(accountTypes);
            Assert.NotNull(paymentPlans);
            Assert.NotNull(createAccount);

        }



    }
}
