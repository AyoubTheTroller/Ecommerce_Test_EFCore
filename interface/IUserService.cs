using Ecommerce.Models;
namespace Ecommerce.interfaces{
    public interface IUserService{
        public Task<User> addUser(User user);
        public Task<User?> getUser(int id);
        public Task<List<User>> getAllUsers();
    }
}