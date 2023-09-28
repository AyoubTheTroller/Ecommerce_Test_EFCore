using Ecommerce.DTO;
using Ecommerce.interfaces;
using Ecommerce.Exceptions;
using Ecommerce.Middlewares;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Controllers{
    public static class UserController{
        public static void MapUserRoutes(WebApplication app){
            MapGetAllUsers(app);
            MapGetUserById(app);
            MapSignUp(app);
            MapLoginUser(app);
        }

        private static void MapLoginUser(WebApplication app)
        {
            app.MapPost("/users/login", async (LoginDTO loginDto, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IJwtService jwtService) =>
            {
                var result = await signInManager.PasswordSignInAsync(loginDto.username, loginDto.password, false, false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(loginDto.username);
                    var token = jwtService.GenerateToken(user);
                    return Results.Ok(new { token });
                }
                return Results.Unauthorized();
            });
        }

        private static void MapGetAllUsers(WebApplication app){
            app.MapGet("/users", async (IUserService userService) => await userService.GetAllUsers());
        }

        private static void MapGetUserById(WebApplication app){
            app.MapGet("/users/{id}", async (string id, IUserService userService) =>
            {
                var user = await userService.GetUser(id);
                if (user == null)
                {
                    throw new UserNotFoundException(user.UserName);
                }
                return Results.Ok(user);
            });
        }

        private static void MapSignUp(WebApplication app)
        {
            app.MapPost("/users/signup", async (UserSignUpDTO signUpDTO, IUserService userService) =>
            {
                if (string.IsNullOrWhiteSpace(signUpDTO.Password))
                {
                    throw new ArgumentNullException(nameof(signUpDTO.Password), "Password cannot be null or empty.");
                }

                var user = new IdentityUser
                {
                    UserName = signUpDTO.UserName,
                    Email = signUpDTO.Email
                };

                IdentityUser addedUser = await userService.AddUser(user, signUpDTO.Password);
                
                return Results.Created($"/users/{addedUser.Id}", addedUser);
            });
        }

    }
}
