using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Repositories.Implementation
{

    public class PaymentPlanAccountsRepository : BaseRepository<PaymentPlanAccount, SDBOAppContext>, Social.Data.Repositories.IPaymentPlanAccountsRepository
    {
        public PaymentPlanAccountsRepository(SDBOAppContext context)
            :base(context)
        {
            
        }

        public void TestMethod()
        {
            //remove this
        }

    }
}