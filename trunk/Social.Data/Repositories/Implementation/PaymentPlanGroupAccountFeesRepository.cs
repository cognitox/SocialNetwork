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

    public class PaymentPlanGroupAccountFeesRepository : BaseRepository<PaymentPlanGroupAccountFee, SDBOAppContext>, Social.Data.Repositories.IPaymentPlanGroupAccountFeesRepository
    {
        public PaymentPlanGroupAccountFeesRepository(SDBOAppContext context)
            : base()
        {
            SetContext(context);
        }

        public void TestMethod()
        {
            //remove this
        }

    }
}