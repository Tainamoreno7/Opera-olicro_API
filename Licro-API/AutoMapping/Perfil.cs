using AutoMapper;
using Dominio.Modelos;
using Dominio.ViewModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licro_API.AutoMapping
{
    public class Perfil : Profile
    {
       public Perfil()
        {
            CreateMap<User, UserView>();
            CreateMap<Anuncio, AnuncioView>()
                .AfterMap((s, d, context) =>
                {
                    d.Endereco = context.Mapper.Map<EnderecoView>(s.Endereco);
                    d.User = context.Mapper.Map<UserView>(s.User);
                })
                .ReverseMap();

            CreateMap<Endereco, EnderecoView>();


                //.ForMember(d=> d.UserId, o => o.MapFrom(s => s.User.Id))
                //.ForMember(d => d.Cidade, o => o.MapFrom(s => s.Endereco.Cidade))
                //.ForMember(d => d.Estado, o => o.MapFrom(s => s.Endereco.Estado));
        }
    }
}
