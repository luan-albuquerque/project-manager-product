using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TesteVagaDevPleno.Modules.AuthModule.Dtos;
using TesteVagaDevPleno.Modules.AuthModule.Services;
using TesteVagaDevPleno.Modules.UserModule.Repository.contract;

namespace TesteVagaDevPleno.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthController :  ControllerBase
    {
        AuthService _authService;


        public AuthController(UserRepository userRepository)
        {
            _authService = new AuthService(userRepository);
          
        }

        [HttpPost("")]
        [SwaggerOperation(Summary = "Autenticação de Usuário", Description = "EndPoint para realização de autenticação de usuario - Para testes use > email: bugas@gmail.com password: bugas123")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ILoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Auth(IAuthDTO authDTO)
        {
            try
            {
                var token = await _authService.Execute(authDTO);

                return Ok(token);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
