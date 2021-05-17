using Database.Interfaces;
using Database.Repositories;
using NHibernate;
using System;
using Dominio.Modelos;

namespace Database
{
    public class AnuncioRepository : Repository<Anuncio>, IAnuncioRepository
    {
        public AnuncioRepository(ISession session) : base(session)
        {
        }

    }
}
