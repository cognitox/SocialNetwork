using System;
using System.Collections.Generic;
using System.Data.Entity;
namespace Social.Data.Repositories.Base
{
    public interface IBaseRepository<TEntity, TDbContext>
        where TEntity : class
        where TDbContext : System.Data.Entity.DbContext
    {
        List<TEntity> Where(Func<TEntity, bool> predicate);
        List<TEntity> Where(Func<TEntity, int, bool> predicate);
        System.Collections.Generic.List<TEntity> Create(System.Collections.Generic.List<TEntity> models);
        TEntity Create(TEntity model);
        System.Collections.Generic.List<TEntity> CreateOrUpdate(System.Collections.Generic.List<TEntity> model);
        TEntity CreateOrUpdate(TEntity model);
        bool Exists(Guid model);
        System.Collections.Generic.List<TEntity> HardDelete(System.Collections.Generic.List<Guid> model);
        System.Collections.Generic.List<TEntity> HardDelete(System.Collections.Generic.List<TEntity> model);
        TEntity HardDelete(Guid model);
        TEntity HardDelete(TEntity model);
        TEntity Read(Guid model);
        TEntity Read(TEntity model);
        System.Collections.Generic.List<TEntity> ReadAll();
        void SetContext(TDbContext dbcontext);
        System.Collections.Generic.List<TEntity> SoftDelete(System.Collections.Generic.List<Guid> models);
        System.Collections.Generic.List<TEntity> SoftDelete(System.Collections.Generic.List<TEntity> model);
        TEntity SoftDelete(Guid model);
        TEntity SoftDelete(TEntity model);
        System.Collections.Generic.List<TEntity> Update(System.Collections.Generic.List<TEntity> models);
        TEntity Update(TEntity model);
    }
}
