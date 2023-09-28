using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.interfaces{
    public interface IUserService{
        Task<IdentityUser> AddUser(IdentityUser user, string password);
        Task<IList<IdentityUser>> GetAllUsers();
        Task<IdentityUser?> GetUser(int userId);
    }
}