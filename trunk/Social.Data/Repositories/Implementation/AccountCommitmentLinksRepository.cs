﻿using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Repositories.Implementation
{

    public class AccountCommitmentLinksRepository : BaseRepository<AccountCommitmentLink, SDBOAppContext>, Social.Data.Repositories.IAccountCommitmentLinksRepository
    {
        public AccountCommitmentLinksRepository(SDBOAppContext context)
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