using Social.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Repositories.Base.Implementation
{
    public class CRUDMethods<TEntity, TDbContext> : Social.Data.Repositories.Base.ICRUDMethods<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        private TDbContext _dbcontext;
        private DbSet<TEntity> _entitycontext;
        private IRepoUtilities<TEntity> _repositoryUtilities;


        public CRUDMethods(TDbContext dbcontext)
        {
            //get the database context
            _dbcontext = dbcontext;
            //get the entity context
            _entitycontext = _dbcontext.Set<TEntity>();
            //common repository utilities
            _repositoryUtilities = new RepoUtilities<TEntity>();
        }

        /// <summary>
        /// Creates a new model in the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TEntity Create(TEntity model)
        {
            TEntity retVal = null;
            if (!IsSystemAccount(model))
            {
                var repoUtilities = new RepoUtilities<TEntity>();
                retVal = repoUtilities.ExecuteInRetryLoop(() =>
                {
                    TEntity ret;
                    _repositoryUtilities.SetPKValue(model, Guid.NewGuid());
                    ret = _entitycontext.Add(model);
                    _dbcontext.Entry(model).State = EntityState.Added;
                    _dbcontext.SaveChanges();
                    return ret;
                });
            }
            else
            {
                throw new Exception("model cannot be of system type");
            }
            return retVal;
        }

        /// <summary>
        /// Creates a list of models, returning the 
        /// list of newly created models
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public List<TEntity> Create(List<TEntity> models)
        {
            List<TEntity> retList = new List<TEntity>();
            foreach (var m in models)
            {
                retList.Add(Create(m));
            }
            return retList.OrderBy(a => _repositoryUtilities.GetPKValue(a)).ToList();
        }

        /// <summary>
        /// Reads By ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public TEntity Read(Guid model)
        {
            return _entitycontext.Find(model);
        }

        /// <summary>
        /// Reads a model from the database by a model, using the modelID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TEntity Read(TEntity model)
        {
            return Read(_repositoryUtilities.GetPKValue(model));
        }


        //READ
        /// <summary>
        /// Reads all, ordered by primary key
        /// </summary>
        /// <returns></returns>
        public List<TEntity> ReadAll()
        {
            return _entitycontext.ToList();
        }

        /// <summary>
        /// Updates a model, returning the updated model from the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TEntity Update(TEntity model)
        {
            TEntity retVal = null;
            var pkValue = _repositoryUtilities.GetPKValue(model);
            var exists = _entitycontext.Find(pkValue);
            if (null != exists &&
                !IsSystemAccount(exists) &&
                !IsModelSystemType(exists))
            {
                var repoUtilities = new RepoUtilities<TEntity>();
                retVal = repoUtilities.ExecuteInRetryLoop(() =>
                {
                    TEntity ret;
                    ret = _entitycontext.Attach(model);
                    _dbcontext.Entry(model).State = EntityState.Modified;
                    _dbcontext.SaveChanges();
                    return ret;
                });
            }
            else
            {
                throw new Exception(@"Cannot update a model that doesn't exist in the database.");
            }
            return retVal;
        }

        /// <summary>
        /// Updates a list of models, returning the list of models from the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TEntity> Update(List<TEntity> models)
        {
            List<TEntity> retList = new List<TEntity>();
            foreach (var m in models)
            {
                retList.Add(Update(m));
            }
            return retList.OrderBy(a => _repositoryUtilities.GetPKValue(a)).ToList();
        }

        /// <summary>
        /// Creates or updates a model in the database, based on the models ID
        /// If the model ID is a zeroed guid, then the model will be created, 
        /// else the model will be updated, returning the model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TEntity CreateOrUpdate(TEntity model)
        {
            TEntity retVal = null;
            if (!IsSystemAccount(model)) // make sure model is not a system account
            {
                var pkValue = _repositoryUtilities.GetPKValue(model);
                var exists = _entitycontext.Find(pkValue);
                if (null != exists &&
                    !IsModelSystemType(exists))
                {
                    retVal = Update(model);
                }
                else
                {
                    retVal = Create(model);
                }
            }
            return retVal;
        }

        /// <summary>
        /// Creates or updates a list model in the database, based on the models ID
        /// If the model ID is a zeroed guid, then the model will be created, 
        /// else the model will be updated, returning the list of models
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TEntity> CreateOrUpdate(List<TEntity> model)
        {

            var retVals = new List<TEntity>();
            foreach (var m in model)
            {
                retVals.Add(CreateOrUpdate(m));
            }
            return retVals;
        }

        /// <summary>
        /// Takes in a Guid, and sets the 'IsDeleted' Flag to true
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public TEntity SoftDelete(Guid model)
        {
            TEntity retVal = null;
            var pkValue = model;
            var exists = _entitycontext.Find(pkValue);
            if (null != exists &&
                !IsSystemAccount(exists) &&
                !IsModelSystemType(exists))
            {
                _repositoryUtilities.SetSoftDelete(exists, true);
                retVal = Update(exists);
            }
            else
            {
                
                throw new Exception(@"Cannot soft delete an entity 
                                      that either doesn't exist or 
                                      is a system type or is a system 
                                      account");
                 
            }
            return retVal;
        }

        /// <summary>
        /// Takes in TEntity, and sets the 'IsDeleted' Flag to true
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public TEntity SoftDelete(TEntity model)
        {
            return SoftDelete(_repositoryUtilities.GetPKValue(model));
        }

        /// <summary>
        /// Takes in a List of TEntity, and sets the 'IsDeleted' Flag to true
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public List<TEntity> SoftDelete(List<TEntity> model)
        {

            var retVals = new List<TEntity>();
            foreach (var m in model)
            {
                retVals.Add(SoftDelete(m));
            }
            return retVals;
        }

        /// <summary>
        /// Takes in a List of Guids, and sets the 'IsDeleted' Flag to true
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public List<TEntity> SoftDelete(List<Guid> models)
        {
            var retVals = new List<TEntity>();
            foreach (var m in models)
            {
                retVals.Add(SoftDelete(m));
            }
            return retVals;
        }


        /// <summary>
        /// Hard Deletes a TEntity by Guid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TEntity HardDelete(Guid model)
        {

            TEntity retVal = null;
            var pkValue = model;
            var exists = _entitycontext.Find(pkValue);
            if (null != exists &&
                !IsSystemAccount(exists) &&
                !IsModelSystemType(exists))
            {
                _entitycontext.Remove(exists);
                _dbcontext.Entry(exists).State = EntityState.Deleted;
                _dbcontext.SaveChanges();
                retVal = exists;
            }
            else
            {
                
                throw new Exception(@"Cannot hard delete an entity 
                                      that either doesn't exist or 
                                      is a system type, or is a system 
                                      account");
                 
            }
            return retVal;
        }

        public Boolean Exists(Guid model)
        {
            Boolean retVal = false;
            var pkValue = model;
            var exists = _entitycontext.Find(pkValue);
            if (null != exists)
            {
                retVal = true;
            }

            return retVal;
        }

        /// <summary>
        /// Hard Deletes a TEntity by TEntity
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public TEntity HardDelete(TEntity model)
        {
            return HardDelete(_repositoryUtilities.GetPKValue(model));
        }

        /// <summary>
        /// Deletes the List<TEntity> from the database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TEntity> HardDelete(List<TEntity> model)
        {
            var retVals = new List<TEntity>();
            foreach (var m in model)
            {
                retVals.Add(HardDelete(m));
            }
            return retVals;
        }

        /// <summary>
        /// Hard Deletes a List of TEntity Guid's
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TEntity> HardDelete(List<Guid> model)
        {
            var retVals = new List<TEntity>();
            foreach (var m in model)
            {
                retVals.Add(HardDelete(m));
            }
            return retVals;
        }


        /// <summary>
        /// Validates the model to check if it is a system account,
        /// only executes if the type is of account type
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Boolean IsSystemAccount(TEntity model)
        {
            var retVal = true;
            if (typeof(TEntity) == typeof(Account)) //if is an account
            {
                var email = _repositoryUtilities.GetAccountEmail(model);

                var systemAccountEmails = new List<String>()
                { 
                  @"master@relsocial.com",
                  @"administration@relsocial.com",
                  @"service@relsocial.com"
                };

                if (!systemAccountEmails.Contains(email.ToLower().Trim()))
                {
                    retVal = false;
                }
            }
            else
            {
                retVal = false;
            }
            return retVal;
        }

        /// <summary>
        /// Validates the model to check if it is a system type,
        /// Checks to see if the guid is 0000-0000....
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Boolean IsModelSystemType(TEntity model)
        {
            var retVal = true;
            var pkValue = _repositoryUtilities.GetPKValue(model);

            if (pkValue != new Guid())
            {
                retVal = false;
            }
            return retVal;
        }
    }
}
