using TesteVagaDevPleno.Modules.UserModule.Entity;

namespace TesteVagaDevPleno.Modules.UserModule.Repository.contract
{
    public abstract class UserRepository
    {
        public abstract Task<User> findMail(string mail);
    }
}
