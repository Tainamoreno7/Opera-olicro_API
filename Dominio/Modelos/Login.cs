using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Login:BaseEntity
    {
        public virtual string Email { get; set; }
        public virtual string Senha { get; set; }
        public virtual User User { get; set; }
    }
}
