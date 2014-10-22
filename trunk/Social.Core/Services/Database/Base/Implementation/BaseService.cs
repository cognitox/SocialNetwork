using Social.Data.DatabaseContext;
using Social.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Services.Database.Base.Implementation
{
    public class BaseService<TEntity> : Social.Core.Services.Database.Base.IBaseService<TEntity>
        where TEntity : class
    {
        protected IUnitOfWork _unitOfWork;
        public void SetContext(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }


}