using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Data.Repositories.Base.Implementation
{
    public class BaseRepository<TEntity, TDbContext> : Social.Data.Repositories.Base.IBaseRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        protected TDbContext _context;
        protected CRUDMethods<TEntity, TDbContext> _crudMethods;
    
        public BaseRepository(TDbContext context)
        {
            _context = context;
            _crudMethods = new CRUDMethods<TEntity, TDbContext>(_context);
        }

        public List<TEntity> Read()
        {
            return _crudMethods.ReadAll();
        }

        public TEntity Read(Guid Id)
        {
            return _crudMethods.Read(Id);
        }
        
        public TEntity Add(TEntity model)
        {
            return _crudMethods.Create(model);
        }
        
        public TEntity SoftDelete(Guid Id)
        {
            return _crudMethods.SoftDelete(Id);
        }

        public Boolean Exists(Guid Id)
        {
            return _crudMethods.Exists(Id);
        }
    }
}
