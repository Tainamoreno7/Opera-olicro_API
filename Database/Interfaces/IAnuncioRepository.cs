using Dominio.Enums;
using Dominio.Modelos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IAnuncioRepository : IRepository<Anuncio>
    {
        Task<IQueryable<Anuncio>> GetByUserId(Guid id);
        Task<IQueryable<Anuncio>> GetByTipo(TipoCategoria tipoCategoria);

    }
}
