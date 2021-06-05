using System;
using System.Collections.Generic;
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator._202105171321
{

    [Migration(202106011447)]
    public class Migration202106011447 : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Schema("dbo")
                     .Table("Endereco")
                     .Exists())
            {
                Create
                .Table("Endereco")
                    .InSchema("dbo")
                    .WithColumn("EnderecoId")
                    .AsGuid()
                    .PrimaryKey()
                    .WithColumn("CEP")
                    .AsString()
                    .Nullable()
                    .WithColumn("Rua")
                    .AsString()
                    .Nullable()
                    .WithColumn("Complemento")
                    .AsString()
                    .Nullable()
                    .WithColumn("Bairro")
                    .AsString()
                    .Nullable()
                    .WithColumn("Numero")
                    .AsString()
                    .Nullable()
                    .WithColumn("Cidade")
                    .AsString()
                    .Nullable()
                    .WithColumn("Estado")
                    .AsString()
                    .Nullable()
                    .WithColumn("LastUpdate")
                    .AsString(1000)
                    .Nullable();
            }
        
        }
    }
    
}
