using Ecommerce.Models;
using Ecommerce.interfaces;

namespace Ecommerce.Controllers{
    public static class ProductController{
        public static void MapProductRoutes(WebApplication app){
            MapGetAllProducts(app);
            MapGetProductById(app);
            MapCreateProduct(app);
            MapGetAllProductsByCategorySlug(app);
        }

        private static void MapGetAllProductsByCategorySlug(WebApplication app)
        {
            app.MapGet("/products/category/{slug}", async (string slug, IProductService productService) =>
            {
                var products = await productService.getAllProductsByCategorySlug(slug);
                return Results.Ok(products);
            });
        }

        private static void MapGetAllProducts(WebApplication app){
            app.MapGet("/products", (IProductService productService) => productService.getAllProducts());
        }

        private static void MapGetProductById(WebApplication app){
            app.MapGet("/products/{id:int}", (int id, IProductService productService) =>
            {
                var product = productService.getProduct(id);
                return Results.Ok(product);
            });
        }

        private static void MapCreateProduct(WebApplication app){
            app.MapPost("/products/create", (Product product, IProductService productService) =>
            {
                var addedProduct = productService.addProduct(product);
                return Results.Created($"/products/create/{addedProduct.Id}", addedProduct);
            });
        }
    }
}
