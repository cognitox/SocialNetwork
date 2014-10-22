using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface IPaymentPlanAccountsRepository : IBaseRepository<PaymentPlanAccount, SDBOAppContext> 
    {
        void TestMethod();
    }
}
