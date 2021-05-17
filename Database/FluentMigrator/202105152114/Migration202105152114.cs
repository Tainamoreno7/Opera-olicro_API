using System;
using System.Collections.Generic;
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator._202105152114
{

    [Migration(202105152114)]
    public class Migration202105171321 : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Schema("dbo")
               .Table("Anuncio")
               .Exists())
            {
                Create
                .Table("Anuncio")
                    .InSchema("dbo")
                    .WithColumn("AnuncioId")
                    .AsGuid()
                    .PrimaryKey()
                    .WithColumn("TipoCategoria")
                    .AsInt32()
                    .NotNullable()
                    .WithColumn("TipoNegocio")
                    .AsInt32()
                    .NotNullable()
                    .WithColumn("Residuo")
                    .AsString()
                    .NotNullable()
                    .WithColumn("LastUpdate")
                    .AsString(1000)
                    .Nullable();
            }

            //Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra", TipoCategoria = 1, TipoNegocio = 1 });
            //Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra1", TipoCategoria = 2, TipoNegocio = 2 });
            //Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra2", TipoCategoria = 3, TipoNegocio = 3 });
            //Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra3", TipoCategoria = 4, TipoNegocio = 4 });

        }
    }
    
}
