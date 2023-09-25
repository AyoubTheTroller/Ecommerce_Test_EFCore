using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.interfaces;
using Ecommerce.services;
using Ecommerce.Repositories;
using Ecommerce.Models;
using Ecommerce.Middlewares;

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
builder.Services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var context = scope.ServiceProvider.GetRequiredService<EcommerceDbContext>();
    context.Database.Migrate();
}

// MIDDLEWARES
app.UseMiddleware<ErrorHandlerMiddleware>();


// CONTROLLERS
Ecommerce.Controllers.UserController.MapUserRoutes(app);
Ecommerce.Controllers.ProductController.MapProductRoutes(app);
Ecommerce.Controllers.CategoryController.MapCategoryRoutes(app);
Ecommerce.Controllers.OrderController.MapOrderRoutes(app);

app.Run();