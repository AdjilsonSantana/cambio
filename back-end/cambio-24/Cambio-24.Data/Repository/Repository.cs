using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cambio_24.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly Cambio24Context _context;
        private readonly DbSet<T> _dataset;
        public Repository(Cambio24Context context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Insert(T item)
        {
            try
            {
                item.CreatedAt = DateTime.UtcNow;
                _dataset.Add(item);
            }
            catch (Exception ex)
            {
                return null;
            }

            return item;
        }

        public T Get(long id)
        {
            try
            {
                return _dataset.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public IList<T> Get()
        {
            try
            {
                return _dataset.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public T Update(T item)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));
                if (result == null)
                    return null;

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
            }
            catch (Exception ex)
            {
                return null;
            }

            return item;
        }

        public bool Delete(long id)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                //_context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
