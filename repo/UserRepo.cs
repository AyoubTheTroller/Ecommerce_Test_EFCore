using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories{
    public class UserRepo : IUserRepo
    {
        private readonly EcommerceDbContext _context;

        public UserRepo(EcommerceDbContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            try{
                _context.Users.Add(user);
                return user;
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error when adding user: {ex.Message}");
            }
        }

        public async Task<User?> Get(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        
    }
}
