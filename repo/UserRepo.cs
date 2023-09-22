using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;

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
                _context.SaveChanges();
                return user;
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Error when adding user: {ex.Message}");
            }
        }

        public User? Get(int id)
        {
            return _context.Users.FirstOrDefault(a => a.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        
    }
}
