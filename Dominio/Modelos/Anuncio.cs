using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Anuncio:BaseEntity
    {
        
        public virtual TipoCategoria TipoCategoria { get; set; }

        public virtual TipoNegocio TipoNegocio { get; set; }

        public virtual string Residuo { get; set; } 
    }
}
