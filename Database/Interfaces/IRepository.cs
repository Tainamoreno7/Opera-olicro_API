using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);

        Task<TEntity> GetByIdAsync(object id);

        IQueryable<TEntity> GetAll();

        Task UpdateAsync(TEntity entity);

        Task RemoveAsync(object id);

        Task SaveOrUpdateAsync(TEntity entity);

        Task FlushAsync();
    }
}
