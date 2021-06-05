using Dominio.Modelos;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Mappings
{
    public class LoginMap : ClassMapping<Login>
    {
        public LoginMap(){
            Table("[Login]");
            Schema("dbo");

        Id(x => x.Id, map =>
            {
            map.Column("LoginId");
            map.Generator(Generators.GuidComb);
        });

            Property(x => x.Email);
            Property(x => x.Senha);


            OneToOne(p => p.User, map => {
                map.Constrained(false);
            });
        }
}
}
