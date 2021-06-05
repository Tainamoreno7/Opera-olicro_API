using Database.Interfaces;
using Database.Repositories;
using NHibernate;
using System;
using Dominio.Modelos;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Dominio.Enums;

namespace Database.Repositories
{
    public class AnuncioRepository : Repository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(ISession session) : base(session)
        {
        }

        public async Task<IQueryable<Anuncio>> GetByUserId(Guid id)
        {
            var anuncios = Session.Query<Anuncio>()
                 .Where(a => a.User.Id == id);

            return anuncios;
        }
        //public async Task<IQueryable<Anuncio>> GetByTipo(TipoCategoria tipoCategoria)
        //{
        //    IList <Anuncio>  anuncios = Session.Query<Anuncio>()
        //         .Where(a => a.TipoCategoria == tipoCategoria).ToList();

        //    return (IQueryable<Anuncio>)anuncios;

        

        public async Task<IQueryable<Anuncio>> GetByTipo(TipoCategoria tipoCategoria)
        {
            var anuncios = Session.Query<Anuncio>()
              .Where(a => a.TipoCategoria == tipoCategoria);

            return anuncios;




        }
    }
}
