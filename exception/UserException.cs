using Ecommerce.Models;

namespace Ecommerce.Exceptions
{
    public class UserNotFoundException : Exception{
        public UserNotFoundException(string username) : base($"User with username '{username}' not found."){}
    }

    public class UserAlreadyExistsException : Exception{
        public UserAlreadyExistsException(User user) : base($"User with username '{user.Username}' already exists."){}
    }
}
