using Ecommerce.Models;
namespace Ecommerce.interfaces{
    public interface IUserService{
        public User addUser(User user);
        public User? getUser(int id);
        public List<User> getAllUsers();
    }
}