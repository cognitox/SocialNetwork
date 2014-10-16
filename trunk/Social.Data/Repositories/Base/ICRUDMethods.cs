using System;
namespace Social.Data.Repositories.Base
{
    interface ICRUDMethods<TEntity>
     where TEntity : class
    {
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
        System.Collections.Generic.List<TEntity> SoftDelete(System.Collections.Generic.List<Guid> models);
        System.Collections.Generic.List<TEntity> SoftDelete(System.Collections.Generic.List<TEntity> model);
        TEntity SoftDelete(Guid model);
        TEntity SoftDelete(TEntity model);
        System.Collections.Generic.List<TEntity> Update(System.Collections.Generic.List<TEntity> models);
        TEntity Update(TEntity model);
    }
}
