using AutoMapper;
using Database.Interfaces;
using Dominio.Enums;
using Dominio.Modelos;
using Dominio.ViewModelos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licro_API.Controllers
{
    [ApiController]
    [Route("api/anuncio")]
    public class AnuncioController:ControllerBase
    {

        private readonly IAnuncioRepository _anuncioRepository;
        private readonly IMapper _mapper;
        public AnuncioController(IAnuncioRepository anuncioRepository, IMapper mapper)
        {
            _anuncioRepository = anuncioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)

        {

            var anuncios = _anuncioRepository.GetAll();

            if (!anuncios.Any()) {

                return NotFound();
            }               
                anuncios.Where(ac => ac.User.Id != id ).Select(an => new Anuncio {
                     Id = an.Id,
                     Residuo = an.Residuo,
                     TipoCategoria = an.TipoCategoria,
                     TipoNegocio = an.TipoNegocio,
                     Detalhes = an.Detalhes,
                     Endereco = new Endereco { Id = an.Endereco.Id, Cidade = an.Endereco.Cidade, Estado = an.Endereco.Estado },
                     Fotos = an.Fotos,
                     ExtFoto = an.ExtFoto,
                     Frequencia = an.Frequencia,
                     TipoOrigem = an.TipoOrigem,
                     Quantidade = an.Quantidade,
                     Recipiente = an.Recipiente,
                     Solucao = an.Solucao,
                     Titulo = an.Titulo,
                     TipoUnidade = an.TipoUnidade,
                     User = new User { Id = an.User.Id }
                 }).OrderBy(an => an.TipoNegocio).ToList();
                var list = _mapper.Map<List<AnuncioView>>(anuncios);

                return Ok(list);
           } 
        

        [HttpGet]
        [Route("getByUserId/{id}")]
        public async Task<IActionResult> GetByUserId([FromRoute] Guid id)
        {

            var anuncios = await _anuncioRepository.GetByUserId(id);


                 if (!anuncios.Any()) 
                    return NotFound();
                
            anuncios.Select(an => new Anuncio
             {
                Id = an.Id,
                Residuo = an.Residuo,
                TipoCategoria = an.TipoCategoria,
                TipoNegocio = an.TipoNegocio,
                Detalhes = an.Detalhes,
                Endereco = new Endereco { Id = an.Endereco.Id, Cidade = an.Endereco.Cidade, Estado = an.Endereco.Estado,},
                Fotos = an.Fotos,
                ExtFoto = an.ExtFoto,
                Frequencia = an.Frequencia,
                TipoOrigem = an.TipoOrigem,
                Quantidade = an.Quantidade,
                Recipiente = an.Recipiente,
                Solucao = an.Solucao,
                Titulo = an.Titulo,
                TipoUnidade = an.TipoUnidade,
                User = new User { Id = an.User.Id}
            }).OrderBy(an => an.TipoNegocio).ToList();

            var list = _mapper.Map<List<AnuncioView>>(anuncios);

            return Ok(list);
        }

        [HttpGet]
        [Route("GetByTipo/{tipoCategoria}")]
        public async Task<IActionResult> GetByTipo([FromRoute]TipoCategoria tipoCategoria)
        {

            var anuncios = await _anuncioRepository.GetByTipo(tipoCategoria);


            if (!anuncios.Any())
                return NotFound();

            anuncios.Select(an => new Anuncio
            {
                Id = an.Id,
                Residuo = an.Residuo,
                TipoCategoria = an.TipoCategoria,
                TipoNegocio = an.TipoNegocio,
                Detalhes = an.Detalhes,
                Endereco = new Endereco { Id = an.Endereco.Id, Cidade = an.Endereco.Cidade, Estado = an.Endereco.Estado, },
                Fotos = an.Fotos,
                ExtFoto = an.ExtFoto,
                Frequencia = an.Frequencia,
                TipoOrigem = an.TipoOrigem,
                Quantidade = an.Quantidade,
                Recipiente = an.Recipiente,
                Solucao = an.Solucao,
                Titulo = an.Titulo,
                TipoUnidade = an.TipoUnidade,
                User = new User { Id = an.User.Id }
            }).OrderBy(an => an.TipoNegocio).ToList();

            var list = _mapper.Map<List<AnuncioView>>(anuncios);

            return Ok(list);

        }

        [HttpPost]
        [Route("createAnuncio")]
        public async Task<IActionResult> Create([FromBody] AnuncioComand comand )
        {
            var anuncio = new Anuncio
            {
                Id = comand.Id,
                Residuo = comand.Residuo,
                TipoCategoria = comand.TipoCategoria,
                TipoNegocio = comand.TipoNegocio,
                Detalhes = comand.Detalhes,
                Endereco = comand.Endereco,
                Fotos = Convert.FromBase64String(comand.Fotos),
                ExtFoto = comand.ExtFoto,
                Frequencia = comand.Frequencia,
                TipoOrigem = comand.TipoOrigem,
                Quantidade = comand.Quantidade,
                Recipiente = comand.Recipiente,
                Solucao = comand.Solucao,
                Titulo = comand.Titulo,
                TipoUnidade = comand.TipoUnidade,
                User = comand.User,
            };
            var result = _anuncioRepository.AddAsync(anuncio);

            if (!result.IsCompletedSuccessfully)
                return BadRequest();

            return Ok();
        }


        [HttpPut]
        [Route("updateAnuncio")]
        public async Task<IActionResult> Update([FromBody] AnuncioComand comand)
        {
            var anuncio = new Anuncio
            {
                Id = comand.Id,
                Residuo = comand.Residuo,
                TipoCategoria = comand.TipoCategoria,
                TipoNegocio = comand.TipoNegocio,
                Detalhes = comand.Detalhes,
                Endereco = comand.Endereco,
                Fotos = Convert.FromBase64String(comand.Fotos),
                ExtFoto = comand.ExtFoto,
                Frequencia = comand.Frequencia,
                TipoOrigem = comand.TipoOrigem,
                Quantidade = comand.Quantidade,
                Recipiente = comand.Recipiente,
                Solucao = comand.Solucao,
                Titulo = comand.Titulo,
                TipoUnidade = comand.TipoUnidade,
                User = comand.User,
            };
            var result = _anuncioRepository.UpdateAsync(anuncio);

            if (!result.IsCompletedSuccessfully)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("deleteAnuncio/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = _anuncioRepository.RemoveAsync(id);

            if (!result.IsCompletedSuccessfully)
                return BadRequest();

            return Ok();
        }
    }

}
    

