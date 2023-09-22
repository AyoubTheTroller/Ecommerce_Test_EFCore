using Ecommerce.interfaces;
using Ecommerce.Models;

namespace Ecommerce.services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User addUser(User user)
        {
            var addedUser = _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();
            return addedUser;
        }

        public List<User> getAllUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public User? getUser(int id)
        {
            return _unitOfWork.UserRepository.Get(id);
        }
    }
}
