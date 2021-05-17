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
        public IEnumerable<Anuncio> Get()
        {

            var anuncios = _anuncioRepository.GetAll().Select(an => new Anuncio { 
            Id = an.Id,
            Residuo = an.Residuo,
            TipoCategoria = an.TipoCategoria,
            TipoNegocio = an.TipoNegocio
            }).OrderBy(an => an.TipoNegocio).ToList();

            return anuncios;
        }

        [HttpPost]
        [Route("residuo")]
        public async Task<IActionResult> Create([FromBody] Anuncio anuncio)
        {
            var result = _anuncioRepository.AddAsync(anuncio);

            if (!result.IsCompleted)
                return BadRequest();

            return Ok();
        }
    }

}
    

