using Dominio.Modelos;

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Mappings
{
    public class AnuncioMap : ClassMapping<Anuncio>
    {
        public AnuncioMap()
        {
            Table("Anuncio");
            Schema("dbo");

            Id(x => x.Id, map =>
            {
                map.Column("AnuncioId");
                map.Generator(Generators.GuidComb);
                map.Generator(Generators.Foreign<Anuncio>(e => e.Endereco));
            });

            Property(x => x.Residuo);
            Property(x => x.TipoCategoria);
            Property(x => x.TipoNegocio);
            Property(x => x.Titulo);
            Property(x => x.TipoOrigem, map =>
            {
                map.Column("Origem");
                map.NotNullable(true);
               
            });
            Property(x => x.Detalhes);
            Property(x => x.TipoUnidade, map =>
            {
                map.Column("Unidade");
                map.NotNullable(true);

            });
            Property(x => x.Quantidade);
            Property(x => x.Recipiente);
            Property(x => x.Frequencia);
            Property(x => x.Solucao);
            Property(x => x.ExtFoto, map =>
            {
                map.Column("ExtFoto");
                map.NotNullable(false);
            });
            Property(x => x.Fotos, map =>
            {
                map.Column("Fotos");
                map.NotNullable(false);
                map.Type<BinaryBlobType>();
            });

            OneToOne(p => p.Endereco, map =>
            {  
                map.Constrained(true);
            });

            ManyToOne(p => p.User, map => {
               
                map.Cascade(Cascade.None);
                map.NotNullable(true);
                map.Column("UserId");
                map.Update(true);
                map.Insert(true);
                
               

            });






        

        }
    }
}
