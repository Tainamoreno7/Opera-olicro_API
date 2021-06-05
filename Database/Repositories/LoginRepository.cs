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
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(ISession session) : base(session)
        {
        }

        public async Task<bool> LoginByEmailAndPass(string email, string senha)
        {
            var login = Session.Query<Login>()
                 .Where(a => a.Email == email && a.Senha == senha);

            if( !login.Any()){
                return false;
            }

            return true;

        }


    }
}
