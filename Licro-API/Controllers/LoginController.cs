using AutoMapper;
using Database.Interfaces;
using Dominio.Enums;
using Dominio.Modelos;
using Dominio.ViewModelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licro_API.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController: ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        public LoginController(ILoginRepository loginRepository, IUserRepository userRepository, IMapper mapper )
        {
            _loginRepository = loginRepository;
            _userRepository = userRepository;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("Authentication")]
        public async Task<IActionResult> CreateSession([FromBody] Login login)
        {
            var hasUser = await _loginRepository.LoginByEmailAndPass(login.Email, login.Senha);
              
            if (hasUser)
            {
                 var result = await _userRepository.GetUserByEmail(login.Email);

                var user = _mapper.Map<UserView>(result);

                return Ok(user);
            }

                return NotFound("Usuário não existe na nossa base de dados");
         }

    }

}
