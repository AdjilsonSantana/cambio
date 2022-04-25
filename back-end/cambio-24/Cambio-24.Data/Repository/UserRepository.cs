using Microsoft.EntityFrameworkCore;
using Cambio_24.Data.Context;
using Cambio_24.Domain.Entities;
using Cambio_24.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cambio_24.Data.Repository
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private readonly DbSet<UserEntity> _dataset;

        public UserRepository(Cambio24Context context) : base(context)
        {
            _dataset = _context.Set<UserEntity>();
        }

        public bool UpdateDateLastAccess(string email)
        {
            try
            {
                var user = _dataset.SingleOrDefault(p => p.Email.Equals(email));
                if (user == null)
                {
                    return false;
                }
                user.LastAccessAt = DateTime.Now;
                _context.Entry(user).CurrentValues.SetValues(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteByEmail(string email)
        {
            try
            {
                var result = _dataset.SingleOrDefault(p => p.Email.Equals(email));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        UserEntity IUserRepository.GetByEmailOrUsername(string email)
        {
            try
            {
                if (!string.IsNullOrEmpty(email))
                    return _dataset.SingleOrDefault(p => p.Email.Equals(email) || p.Username.Equals(email));
                //else if (!string.IsNullOrEmpty(username))
                //    return _dataset.SingleOrDefault(p => p.Username.Equals(username));
            }
            catch (Exception ex)
            {
            }

            return null;
        }
    }
}
