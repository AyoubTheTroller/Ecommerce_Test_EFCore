using Ecommerce.Models;
using Ecommerce.interfaces;

namespace Ecommerce.Controllers{
    public static class CategoryController{
        public static void MapCategoryRoutes(WebApplication app){
            MapGetAllCategories(app);
            MapGetCategoryById(app);
            MapCreateCategory(app);
        }

        private static void MapGetAllCategories(WebApplication app){
            app.MapGet("/categories", (ICategoryService categoryService) => categoryService.getAllCategories());
        }

        private static void MapGetCategoryById(WebApplication app){
            app.MapGet("/categories/{id:int}", (int id, ICategoryService categoryService) =>
            {
                var category = categoryService.GetCategory(id);
                if (category == null)
                {
                    return Results.NotFound($"Category with ID {id} was not found.");
                }
                return Results.Ok(category);
            });
        }

        private static void MapCreateCategory(WebApplication app){
            app.MapPost("/categories/create", (Category category, ICategoryService categoryService) =>
            {
                if (category == null)
                {
                    return Results.BadRequest("Invalid category data.");
                }

                var addedCategory = categoryService.addCategory(category);
                return Results.Created($"/categories/create/{addedCategory.Id}", addedCategory);
            });
        }
    }
}
