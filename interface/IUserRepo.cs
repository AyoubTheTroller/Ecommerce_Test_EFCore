using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.interfaces{
    public interface IUserRepo{
        Task<IdentityUser> Add(IdentityUser user, string password);
        Task<IdentityUser?> Get(int userId);
        Task <IList<IdentityUser>> GetAll();
        Task<bool> UserExistsAsync(string? username);
    }
}