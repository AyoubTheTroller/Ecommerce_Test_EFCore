using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.interfaces{
    public interface IJwtService {
        string GenerateToken(IdentityUser user);
    }
}
