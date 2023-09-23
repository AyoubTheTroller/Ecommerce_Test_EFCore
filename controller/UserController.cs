using Ecommerce.Models;
using Ecommerce.interfaces;
using Ecommerce.Exceptions;

namespace Ecommerce.Controllers{
    public static class UserController{
        public static void MapUserRoutes(WebApplication app){
            MapGetAllUsers(app);
            MapGetUserById(app);
            MapCreateUser(app);
        }

        private static void MapGetAllUsers(WebApplication app){
            app.MapGet("/users", async (IUserService userService) => await userService.getAllUsers());
        }

        private static void MapGetUserById(WebApplication app){
            app.MapGet("/users/{id:int}", async (int id, IUserService userService) =>
            {
                var user = await userService.getUser(id);
                if (user == null)
                {
                    return Results.NotFound($"User with ID {id} was not found.");
                }
                return Results.Ok(user);
            });
        }

        private static void MapCreateUser(WebApplication app){
            app.MapPost("/users/create", async (User user, IUserService userService) =>
            {
                if (user == null)
                {
                    return Results.BadRequest("Invalid user data.");
                }
                try{
                    var addedUser = await userService.addUser(user);
                    return Results.Created($"/users/create/{addedUser.Id}", addedUser);
                }
                catch(UserAlreadyExistsException ex){
                    return Results.Conflict(ex.Message);
                }
            });
        }
    }
}
