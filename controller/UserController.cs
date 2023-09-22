using Ecommerce.Models;
using Ecommerce.interfaces;

namespace Ecommerce.Controllers{
    public static class UserController{
        public static void MapUserRoutes(WebApplication app){
            MapGetAllUsers(app);
            MapGetUserById(app);
            MapCreateUser(app);
        }

        private static void MapGetAllUsers(WebApplication app){
            app.MapGet("/users", (IUserService userService) => userService.getAllUsers());
        }

        private static void MapGetUserById(WebApplication app){
            app.MapGet("/users/{id:int}", (int id, IUserService userService) =>
            {
                var user = userService.getUser(id);
                if (user == null)
                {
                    return Results.NotFound($"User with ID {id} was not found.");
                }
                return Results.Ok(user);
            });
        }

        private static void MapCreateUser(WebApplication app){
            app.MapPost("/users", (User user, IUserService userService) =>
            {
                if (user == null)
                {
                    return Results.BadRequest("Invalid user data.");
                }

                var addedUser = userService.addUser(user);
                return Results.Created($"/users/{addedUser.Id}", addedUser);
            });
        }
    }
}
