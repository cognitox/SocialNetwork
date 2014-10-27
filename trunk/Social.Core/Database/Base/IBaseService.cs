using Social.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Social.Core.Services.Database.Base
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        void SetContext(IUnitOfWork unitOfWork);
    }
}
