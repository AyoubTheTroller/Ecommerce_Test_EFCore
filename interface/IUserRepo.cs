using Ecommerce.Models;
namespace Ecommerce.interfaces{
    public interface IUserRepo{
        public User Add(User user);
        public User? Get(int id);
        public List<User> GetAll();
    }
}