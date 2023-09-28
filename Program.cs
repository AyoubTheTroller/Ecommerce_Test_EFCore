using System.Text;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Data;
using Ecommerce.interfaces;
using Ecommerce.services;
using Ecommerce.Repositories;
using Ecommerce.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<EcommerceDbContext>();
builder.Services.AddScoped<IJwtService, JwtService>();
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

// Authentication middle layer for jwt tokens
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


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