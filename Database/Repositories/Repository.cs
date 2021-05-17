using Database.Interfaces;
using Dominio.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ISession Session;

        protected Repository(ISession session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public Task AddAsync(TEntity entity)
        {
            return Session.SaveAsync(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(object id)
        {
            return Session.GetAsync<TEntity>(id);
        }

        public Task RemoveAsync(object id)
        {
            return Session.DeleteAsync(id);
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Session.UpdateAsync(entity);
        }

        public Task SaveOrUpdateAsync(TEntity entity)
        {
            return Session.SaveOrUpdateAsync(entity);
        }

        public Task FlushAsync()
        {
            return Session.FlushAsync();
        }
    }
}
