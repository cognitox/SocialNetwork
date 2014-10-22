using NUnit.Framework;
using Social.Data.DatabaseContext;
using Social.Data.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.UnitTests.Repositories.Implementation
{
    [TestFixture]
    public class AccountRepository_TestSuite
    {
        [Test]
        public void AccountRepository_Where_Test()
        {
            ///integration test
            var repository = new AccountsRepository(new SDBOAppContext());
            var admin = repository.Where(a => a.Email.Contains("admisdfsdfn"));
            Assert.IsNotNull(admin);
        }
        
    }
}
