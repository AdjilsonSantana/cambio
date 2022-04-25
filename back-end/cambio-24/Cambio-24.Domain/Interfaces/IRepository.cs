using Cambio_24.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Cambio_24.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Insert(T item);

        T Update(T item);

        bool Delete(long id);

        T Get(long id);

        IList<T> Get();
    }
}
