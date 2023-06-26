using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [AllowAnonymous]
        
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
