﻿using Social.Data.DatabaseContext;
using Social.Data.Repositories.Base;
using System;
namespace Social.Data.Repositories
{
    public interface ICommitmentNoteTypesRepository : IBaseRepository<CommitmentNoteType, SDBOAppContext> 
    {
        void TestMethod();
    }
}
