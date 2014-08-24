using Social.Core.UnitOfService.Interface;
using Social.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Social.Core.UnitOfService
{
    public class UnitOfService : IUnitOfService
    {
        private IUnitOfWork _unitOfWork;
    }
}
