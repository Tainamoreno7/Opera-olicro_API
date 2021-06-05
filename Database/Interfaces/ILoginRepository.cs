using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        Task<bool> LoginByEmailAndPass(string email, string senha);

        
    }
}
