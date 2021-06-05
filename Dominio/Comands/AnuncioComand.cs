using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class AnuncioComand : BaseEntity
    {

        public virtual TipoCategoria TipoCategoria { get; set; }
        public virtual TipoNegocio TipoNegocio { get; set; }
        public virtual string Residuo { get; set; }
        public virtual TipoOrigem TipoOrigem { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Detalhes { get; set; }
        public virtual TipoUnidade TipoUnidade { get; set; }
        public virtual string Recipiente { get; set; }
        public virtual string Quantidade { get; set; }
        public virtual string Frequencia { get; set; }
        public virtual string Solucao { get; set;}
        public virtual string Fotos { get; set; }
        public virtual string ExtFoto { get; set;}
       public virtual Endereco Endereco { get; set; }
        public virtual User User { get; set; }
                    


    }
}
