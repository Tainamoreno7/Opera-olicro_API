using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Endereco: BaseEntity
    {
        public virtual string CEP { get; set; }

        public virtual string Rua { get; set; }

        public virtual string Complemento { get; set; }

        public virtual string Bairro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual Anuncio Anuncio { get; set; }
       

    }
}
 