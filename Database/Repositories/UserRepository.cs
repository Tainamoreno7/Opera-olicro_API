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
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
            
        }

        public async Task<bool> FindUserByEmail(string email)
        {
            return Session.Query<User>()
                 .Where(a => a.Login.Email == email).Any();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return Session.Query<User>()
                .Where(a => a.Login.Email == email).First();
        }
    }
}
