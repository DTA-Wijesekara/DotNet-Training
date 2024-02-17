using Microsoft.AspNetCore.Identity;

namespace DotNet_Training.Repositories.AuthRepository
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user , List<string> roles);
    }
}
