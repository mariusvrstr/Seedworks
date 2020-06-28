using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using Seedworks.Conmmon.DAL;

namespace Seedworks.Repositories
{
    public abstract class RepositorySimpleBase<T> : IRepository<T>
        where T : class, IEntityBase
    {
        private DbContext Context { get; set; }
        private DbSet<T> _table { get; set; }

        protected RepositorySimpleBase(DbContext dataContext)
        {
            this.Context = dataContext;
            _table = Context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }

        public IList<T> FindAll()
        {
            return _table.ToList();
        }

        public T Add(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }

           return _table.Add(entity);
        }

        public T Update(Guid id, T entity)
        {
            if (id != entity.Id)
            {
                throw new Exception($"Invalid update request. The ID [{id}] is different from the object provided");
            }

            _table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Remove(Guid id)
        {
            var existing = _table.Single(a => a.Id == id);

            if (existing == null)
            {
                throw new ObjectNotFoundException($"Entity [{typeof(T)}] with ID [{id}]");
            }

            _table.Remove(existing);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
