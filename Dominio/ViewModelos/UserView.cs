using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Dominio.ViewModelos
{
    public class UserView
    {
        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual string Pais { get; set; }
        public  virtual string Whatsapp { get; set; }
        public  virtual bool Termos { get; set; }
    }
}
