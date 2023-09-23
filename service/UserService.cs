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

        public async Task<User> addUser(User user)
        {
            var addedUser = await _unitOfWork.UserRepository.Add(user);
            await _unitOfWork.CommitAsync();
            return addedUser;
        }

        public async Task<List<User>> getAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User?> getUser(int id)
        {
            return await _unitOfWork.UserRepository.Get(id);
        }
    }
}
