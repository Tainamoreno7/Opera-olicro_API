using System;
using System.Collections.Generic;
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator._202105171321
{

    [Migration(202105171321)]
    public class Migration202105171321 : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra", TipoCategoria = 1, TipoNegocio = 1 });
            Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra1", TipoCategoria = 2, TipoNegocio = 2 });
            Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra2", TipoCategoria = 3, TipoNegocio = 3 });
            Insert.IntoTable("Anuncio").InSchema("dbo").Row(new { AnuncioId = Guid.NewGuid(), Residuo = "Alcaxofra3", TipoCategoria = 4, TipoNegocio = 2 });
        }
    }
    
}
