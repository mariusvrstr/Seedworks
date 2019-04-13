using System;
using System.Collections.Generic;

namespace Spike.Seedworks.Conmmon.DAL
{
    public interface IRepository<T> 
        where T : IEntityBase
    {
        T GetById(Guid id);
        IList<T> FindAll();
        T Add(T entity);
        T Update(Guid id, T entity);
        void Remove(Guid id);
        void Save();
    }
}
