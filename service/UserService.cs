using Ecommerce.interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IdentityUser> AddUser(IdentityUser user, string password)
        {
            var addedUser = await _unitOfWork.UserRepository.Add(user, password);
            await _unitOfWork.CommitAsync();
            return addedUser;
        }

        public async Task<IList<IdentityUser>> GetAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task<IdentityUser?> GetUser(string userId)
        {
            return await _unitOfWork.UserRepository.Get(userId);
        }
    }
}