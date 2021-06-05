using Database.Interfaces;
using Dominio.Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Repositories
{
    class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ISession session) : base(session)
        {
        }
    }
}
