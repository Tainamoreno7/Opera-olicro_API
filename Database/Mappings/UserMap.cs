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
                map.Generator(Generators.Foreign<User>(e => e.Login));
            });

            Property(x => x.Nome);
            Property(x => x.Sobrenome);
            Property(x => x.Pais);
            Property(x => x.Whatsapp);
            Property(x => x.Termos);

            OneToOne(p => p.Login, map => { 
                map.Constrained(true);
            });

            Bag(p => p.Anuncios,
                map =>
                {
                    map.Key(x =>
                    {
                        x.Column("UserId");
                    });
                    map.Cascade(Cascade.All | Cascade.DeleteOrphans);
                    map.Inverse(true);
                    map.Fetch(CollectionFetchMode.Join);
                   
                },
                rel =>
                {
                    rel.OneToMany(map => map.Class(typeof(Anuncio)));
                });
        }

    }
}
