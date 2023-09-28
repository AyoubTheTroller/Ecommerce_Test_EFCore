using Ecommerce.interfaces;
using Ecommerce.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRepo(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityUser> Add(IdentityUser user, string password)
        {
            if (await UserExistsAsync(user.UserName))
            {
                throw new UserAlreadyExistsException(user);
            }
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description);
                throw new FailedToCreateUserException(string.Join("; ", errorMessages));
            }
            return user;
        }

        public async Task<IdentityUser?> Get(int userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task <IList<IdentityUser>> GetAll()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<bool> UserExistsAsync(string? username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user != null;
        }
    }
}