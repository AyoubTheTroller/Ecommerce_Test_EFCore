using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Exceptions;

namespace Ecommerce.Repositories{
    public class UserRepo : IUserRepo
    {
        private readonly EcommerceDbContext _context;

        public UserRepo(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user){
            if (user.Username is not null && await UserExistsAsync(user.Username))
            {
                throw new UserAlreadyExistsException(user);
            }
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<User?> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<User>> GetAll(){
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> UserExistsAsync(string username){
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
        
    }
}
