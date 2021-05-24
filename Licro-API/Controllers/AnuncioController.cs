using Database.Interfaces;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
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
        public AnuncioController(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> Get()
        {

            var anuncios = _anuncioRepository.GetAll().Select(an => new Anuncio { 
            Id = an.Id,
            Residuo = an.Residuo,
            TipoCategoria = an.TipoCategoria,
            TipoNegocio = an.TipoNegocio
            }).OrderBy(an => an.TipoNegocio).ToList();

            return Ok(anuncios);
        }

        [HttpGet]
        [Route("getByUserId/{id}")]
        public async Task<IActionResult> GetByUserId([FromRoute] Guid id)
        {

            var anuncios = _anuncioRepository.GetByUserId(id).Result.Select(an => new Anuncio
            {
                Id = an.Id,
                Residuo = an.Residuo,
                TipoCategoria = an.TipoCategoria,
                TipoNegocio = an.TipoNegocio
            }).OrderBy(an => an.TipoNegocio).ToList();

            return Ok(anuncios.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Anuncio anuncio)
        {
            var result = _anuncioRepository.AddAsync(anuncio);

            if (!result.IsCompleted)
                return BadRequest();

            return Ok();
        }


        [HttpPut]
        [Route("updateAnuncio")]
        public async Task<IActionResult> Update([FromBody] Anuncio anuncio)
        {
            var result = _anuncioRepository.UpdateAsync(anuncio);

            if (!result.IsCompleted)
                return BadRequest();

            return Ok();
        }

        [HttpDelete]
        [Route("deleteAnuncio/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = _anuncioRepository.RemoveAsync(id);

            if (!result.IsCompleted)
                return BadRequest();

            return Ok();
        }
    }

}
    

