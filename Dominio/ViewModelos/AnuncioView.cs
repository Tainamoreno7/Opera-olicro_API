using Dominio.Enums;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ViewModelos
{
    public class AnuncioView
    {
        public virtual Guid Id { get; set; }
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
        public virtual byte[] Fotos { get; set; }
        public virtual string ExtFoto { get; set; }
        public virtual EnderecoView Endereco { get; set; }
        public virtual UserView User { get; set; }

    }
}
