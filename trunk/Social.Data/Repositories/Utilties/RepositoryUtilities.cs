using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Repositories.Utilties
{
    public class RepoUtilities<TEntity> 
        where TEntity : class
    {
        private String _primaryKey;
        
        public RepoUtilities()
        {
            //get the primary key name based on the naming convention
            _primaryKey = String.Format(@"{0}ID", typeof(TEntity).Name);
        }

        public TEntity ExecuteInRetryLoop(Func<TEntity> func)
        {
            TEntity retVal = null;

            //create a guid
            var retryAttempt = 0;
            var maxAttempt = 3;
            var success = false;
            while (retryAttempt < maxAttempt
                && !success)
            {
                try
                {
                    retVal = func.Invoke();
                    success = true;
                }
                catch (Exception e)
                {
                    retryAttempt++;
                }

            }
            return retVal;
        }
        public void SetSoftDelete(TEntity model, Boolean value)
        {
            PropertyInfo propertyInfo = model.GetType().GetProperty(@"IsDeleted");
            propertyInfo.SetValue(model, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }

        public void SetPKValue(TEntity model, Guid value)
        {
            PropertyInfo propertyInfo = model.GetType().GetProperty(_primaryKey);
            propertyInfo.SetValue(model, Convert.ChangeType(value, propertyInfo.PropertyType), null);
        }

        public Guid GetPKValue(TEntity model)
        {
            return (Guid)model.GetType().GetProperty(_primaryKey).GetValue(model, null);
        }
        public String GetAccountEmail(TEntity model)
        {
            return (String)model.GetType().GetProperty("Email").GetValue(model, null);
        }

    }
}
