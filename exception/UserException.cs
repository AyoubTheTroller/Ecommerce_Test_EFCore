using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Exceptions
{
    public class UserNotFoundException : Exception{
        public UserNotFoundException(string username) : base($"User with username '{username}' not found."){}
    }

    public class UserAlreadyExistsException : Exception{
        public UserAlreadyExistsException(IdentityUser user) : base($"User with username '{user.UserName}' already exists."){}
    }
    
    public class FailedToCreateUserException : Exception{
        public FailedToCreateUserException(string? errors) : base(errors){}
    }
}
