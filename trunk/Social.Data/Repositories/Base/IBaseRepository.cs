using System;
namespace Social.Data.Repositories.Base
{
    interface IBaseRepository<TEntity>
     where TEntity : class
    {
        TEntity Add(TEntity model);
        bool Exists(Guid Id);
        System.Collections.Generic.List<TEntity> Read();
        TEntity Read(Guid Id);
        TEntity SoftDelete(Guid Id);
    }
}
