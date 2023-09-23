using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.interfaces;
using Ecommerce.services;
using Ecommerce.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var context = scope.ServiceProvider.GetRequiredService<EcommerceDbContext>();
    context.Database.Migrate();
}

Ecommerce.Controllers.UserController.MapUserRoutes(app);
Ecommerce.Controllers.ProductController.MapProductRoutes(app);
Ecommerce.Controllers.CategoryController.MapCategoryRoutes(app);

app.Run();