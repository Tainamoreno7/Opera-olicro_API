using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class User : BaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Pais { get; set; }
        public virtual string Whatsapp { get; set; }
        public virtual string Email { get; set; }

        public virtual string Senha { get; set; }
        
        public virtual bool Termos { get; set; }

        
    }
}
