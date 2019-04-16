using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using Spike.Seedworks.Conmmon.DAL;
using Spike.Seedworks.Repositories.Specification;
using Spike.Seedworks.Repositories.Utilities;

namespace Spike.Seedworks.Repositories
{
    public abstract class RepositoryBase<T, TSpes> : IRepository<T>
        where T : class, IEntityBase
        where TSpes : Specification<T, TSpes>, new()
    {
        protected DbContext Context { get; set; }
        private DbSet<T> _table { get; set; }

        protected RepositoryBase(DbContext dataContext)
        {
            this.Context = dataContext;
            _table = Context.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }

        public IList<T> FindUsingSpecification(Specification<T, TSpes> specification)
        {
            var expression = specification.Create();
            return _table.Where(x => expression.SatisfiedBy(x)).ToList();
        }

        public IList<T> FindAll()
        {
            return _table.ToList();
        }

        public T Add(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = SequentialGuidGenerator.NewSequentialId();
            }

           return _table.Add(entity);
        }

        public T Update(Guid id, T entity)
        {
            if (id != entity.Id)
            {
                throw new Exception($"Invalid update request. The ID [{id}] is different from the object provided");
            }

            Context.Set<T>().AddOrUpdate(entity);

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
