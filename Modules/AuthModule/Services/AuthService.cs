using TesteVagaDevPleno.Config.Error;
using TesteVagaDevPleno.Modules.AuthModule.Dtos;
using TesteVagaDevPleno.Modules.AuthModule.Provider;
using TesteVagaDevPleno.Modules.ProductModule.Repository.contract;
using TesteVagaDevPleno.Modules.UserModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.AuthModule.Services
{
    public class AuthService
    {


        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> Execute(IAuthDTO authDTO)
        {
            if (string.IsNullOrEmpty(authDTO.email) || string.IsNullOrEmpty(authDTO.password))
            {
                throw new ErrorException("email or password  is empty", 401);

            }
            var user = await _userRepository.findMail(authDTO.email);

            if(user == null)
            {
                throw new ErrorException("email or password  is incorrect", 401);

            }


            var token = TokenProvider.GenerateToken(user);



            return token;
        }
    }
}
