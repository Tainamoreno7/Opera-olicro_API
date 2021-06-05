using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ViewModelos
{
    public class EnderecoView
    {
        public virtual Guid Id { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
    }
}
