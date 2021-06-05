using Dominio.Modelos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Mappings
{
    class EnderecoMap : ClassMapping<Endereco>
    {
        public EnderecoMap()
        {

            Table("Endereco");
            Schema("dbo");

            Id(x => x.Id, map =>
            {
                map.Column("EnderecoId");
                map.Generator(Generators.GuidComb);
            });

            Property(x => x.CEP);
            Property(x => x.Rua);
            Property(x => x.Complemento);
            Property(x => x.Bairro);
            Property(x => x.Numero);
            Property(x => x.Cidade);
            Property(x => x.Estado);

            OneToOne(p => p.Anuncio, map =>
            {
                map.Constrained(false);
                
            });

        }
       

}
    }
