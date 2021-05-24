using Database.Interfaces;
using Database.Repositories;
using NHibernate;
using System;
using Dominio.Modelos;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Database
{
    public class AnuncioRepository : Repository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(ISession session) : base(session)
        {
        }

        public async Task<IQueryable<Anuncio>> GetByUserId(Guid id)
        {
            var anuncios = Session.Query<Anuncio>()
                 .Where(a => a.Id == id);

            return anuncios;
        }
    }
}
