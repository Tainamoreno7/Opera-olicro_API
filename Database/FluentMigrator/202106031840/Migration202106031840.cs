using System;
using System.Collections.Generic;
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator._202106031840
{

    [Migration(202106031840)]
    public class Migration202106031840 : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            Alter
             .Table("Anuncio")
                 .InSchema("dbo")
                 .AddColumn("ExtFoto")
                 .AsString()
                 .Nullable();
        }
    }
    
}
