using Dominio.Modelos;

using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
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
            });

            Property(x => x.Residuo, map =>
            {
                map.Column("Residuo");
                map.NotNullable(true);
            });
            Property(x => x.TipoCategoria, map =>
            {
                map.Column("TipoCategoria");
                map.NotNullable(true);
            });
            Property(x => x.TipoNegocio, map =>
            {
                map.Column("TipoNegocio");
                map.NotNullable(true);
            });

        }
    }
}
