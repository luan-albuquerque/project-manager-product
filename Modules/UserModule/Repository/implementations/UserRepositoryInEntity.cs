using Microsoft.EntityFrameworkCore;
using TesteVagaDevPleno.Infra;
using TesteVagaDevPleno.Modules.UserModule.Entity;
using TesteVagaDevPleno.Modules.UserModule.Repository.contract;

namespace TesteVagaDevPleno.Modules.UserModule.Repository.implementations
{
    public class UserRepositoryInEntity : UserRepository
    {
        public readonly ConnectionContext context = new ConnectionContext();
        public override async Task<User> findMail(string mail)
        {
            return await context.Users
                .Where(u => u.email == mail)
                .FirstOrDefaultAsync();
        }
    }
}
