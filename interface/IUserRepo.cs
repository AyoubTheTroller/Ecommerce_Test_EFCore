using Ecommerce.Models;
namespace Ecommerce.interfaces{
    public interface IUserRepo{
        public User Add(User user);
        public Task<User?> Get(int id);
        public Task<List<User>> GetAll();
    }
}