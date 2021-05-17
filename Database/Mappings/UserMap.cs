using Dominio.Modelos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Mappings
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("[User]");
            Schema("dbo");

            Id(x => x.Id, map =>
            {
                map.Column("UserId");
                map.Generator(Generators.GuidComb);
            });

            Property(x => x.Nome);
            Property(x => x.Sobrenome);
            Property(x => x.Pais);
            Property(x => x.Whatsapp);
            Property(x => x.Termos);
            Property(x => x.Email);
            Property(x => x.Senha);
            //Property(x => x.Description, map =>
            //{
            //    map.Column("Description");
            //    map.NotNullable(true);
            //});



            //OneToOne(p => p.Pessoa, map => map.Constrained(true));

            //ManyToOne(x => x.Language, map => map.Column("LanguageId"));
        }

    }
}
