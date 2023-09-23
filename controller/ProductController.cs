using Ecommerce.Models;
using Ecommerce.interfaces;

namespace Ecommerce.Controllers{
    public static class ProductController{
        public static void MapProductRoutes(WebApplication app){
            MapGetAllProducts(app);
            MapGetProductById(app);
            MapCreateProduct(app);
        }

        private static void MapGetAllProducts(WebApplication app){
            app.MapGet("/products", (IProductService productService) => productService.getAllProducts());
        }

        private static void MapGetProductById(WebApplication app){
            app.MapGet("/products/{id:int}", (int id, IProductService productService) =>
            {
                var product = productService.getProduct(id);
                if (product == null)
                {
                    return Results.NotFound($"Product with ID {id} was not found.");
                }
                return Results.Ok(product);
            });
        }

        private static void MapCreateProduct(WebApplication app){
            app.MapPost("/products/create", (Product product, IProductService productService) =>
            {
                if (product == null)
                {
                    return Results.BadRequest("Invalid product data.");
                }

                var addedProduct = productService.addProduct(product);
                return Results.Created($"/products/create/{addedProduct.Id}", addedProduct);
            });
        }
    }
}
