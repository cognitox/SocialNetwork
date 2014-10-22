using System;
namespace Social.Data.Repositories.Base
{
    public interface IRepoUtilities<TEntity>
     where TEntity : class
    {
        TEntity ExecuteInRetryLoop(Func<TEntity> func);
        string GetAccountEmail(TEntity model);
        Guid GetPKValue(TEntity model);
        void SetPKValue(TEntity model, Guid value);
        void SetSoftDelete(TEntity model, bool value);
    }
}
