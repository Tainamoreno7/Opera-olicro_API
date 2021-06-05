using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Boolean> FindUserByEmail(string email);
        Task<User> GetUserByEmail(string email);

    }
}
