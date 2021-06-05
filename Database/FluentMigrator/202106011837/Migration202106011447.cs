using System;
using System.Collections.Generic;
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator._202105171321
{

    [Migration(202106011837)]
    public class Migration202106011837 : Migration
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
                    .WithColumn("Titulo")
                    .AsString()
                    .Nullable()
                    .WithColumn("Origem")
                    .AsInt32()
                    .NotNullable()
                    .WithColumn("Detalhes")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Unidade")
                    .AsInt32()
                    .NotNullable()
                    .WithColumn("Quantidade")
                    .AsInt32()
                    .NotNullable()
                    .WithColumn("Recipiente")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Frequencia")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Solucao")
                    .AsString()
                    .Nullable()
                    .WithColumn("Fotos")
                    .AsCustom("Image")
                    .Nullable()
                    .WithColumn("Documentos")
                    .AsCustom("varbinary(MAX)")
                    .Nullable()
                    .NotNullable()
                    .WithColumn("UserId")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("FK_Anuncio_UserId", "[dbo]", "User", "UserId")
                    .WithColumn("LastUpdate")
                    .AsString(1000)
                    .Nullable();
            }
        }
    }
    
}
