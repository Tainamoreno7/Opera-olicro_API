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
    [Route("api/user")]
    public class UserController : ControllerBase
    {
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Create([FromBody] User user)
    {
            var hasUser = await _userRepository.FindUserByEmail(user.Login.Email);

            if (hasUser)
            {
                return Problem("Já existe um usuário com este email");
            }

            var result = _userRepository.AddAsync(user);

            if (!result.IsCompletedSuccessfully)
                return BadRequest();

            var dataToReturn = await _userRepository.GetByIdAsync(user.Id);

            return Ok(dataToReturn);
        }

    }
}
