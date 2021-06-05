using System;
using System.Collections.Generic;
using FluentMigrator;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Database.FluentMigrator._202105171321
{

    [Migration(202105301056)]
    public class Migration202105301056 : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            if (!Schema.Schema("dbo")
                  .Table("Login")
                  .Exists())
            {
                Create
                .Table("Login")
                    .InSchema("dbo")
                    .WithColumn("LoginId")
                    .AsGuid()
                    .PrimaryKey()
                    .WithColumn("Email")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Senha")
                    .AsString()
                    .NotNullable()
                    .WithColumn("LastUpdate")
                    .AsString(1000)
                    .Nullable();
            }

            if (!Schema.Schema("dbo")
               .Table("User")
               .Exists())
            {
                Create
                .Table("User")
                    .InSchema("dbo")
                    .WithColumn("UserId")
                    .AsGuid()
                    .PrimaryKey()
                    .WithColumn("Nome")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Sobrenome")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Pais")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Whatsapp")
                    .AsString()
                    .NotNullable()
                    .WithColumn("Termos")
                    .AsBoolean()
                    .NotNullable()
                        .WithColumn("LoginId")
                        .AsGuid()
                        .NotNullable()
                        .ForeignKey("FK_User_LoginId", "[dbo]", "Login", "LoginId")
                    .WithColumn("LastUpdate")
                    .AsString(1000)
                    .Nullable();
            }


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
                    .NotNullable()
                    .WithColumn("LastUpdate")
                    .AsString(1000)
                    .Nullable();
            }



            Alter
                .Table("Anuncio")
                    .InSchema("dbo")
                    .AddColumn("Titulo")
                    .AsString()
                    .Nullable()
                    .AddColumn("Origem")
                    .AsInt32()
                    .NotNullable()
                    .AddColumn("Detalhes")
                    .AsString()
                    .NotNullable()
                    .AddColumn("Unidade")
                    .AsInt32()
                    .NotNullable()
                    .AddColumn("Quantidade")
                    .AsInt32()
                    .NotNullable()
                    .AddColumn("Recipiente")
                    .AsString()
                    .NotNullable()
                    .AddColumn("Frequência")
                    .AsString()
                    .NotNullable()
                    .AddColumn("Solucao")
                    .AsString()
                    .Nullable()
                    .AddColumn("Fotos")
                    .AsCustom("Image")
                    .Nullable()
                    .AddColumn("Documentos")
                    .AsCustom("varbinary(MAX)")
                    .Nullable()
                    .AddColumn("EnderecoId")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("FK_Anuncio_EnderecoId", "[dbo]", "Endereco", "EnderecoId")
                    .AddColumn("UserId")
                    .AsGuid()
                    .NotNullable()
                    .ForeignKey("FK_Anuncio_UserId", "[dbo]", "User", "UserId");

                    
        }
    }
    
}
