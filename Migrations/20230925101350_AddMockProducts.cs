using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Project_Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddMockProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Products (Name, Price, CategoryId) 
                SELECT 'Smartphone', 599.99, Id FROM Categories WHERE Slug = 'electronics';
                
                INSERT INTO Products (Name, Price, CategoryId) 
                SELECT 'Washing Machine', 499.99, Id FROM Categories WHERE Slug = 'home-appliances';

                INSERT INTO Products (Name, Price, CategoryId) 
                SELECT 'Jeans', 39.99, Id FROM Categories WHERE Slug = 'fashion';

                INSERT INTO Products (Name, Price, CategoryId) 
                SELECT 'Programming in C#', 29.99, Id FROM Categories WHERE Slug = 'books';

                INSERT INTO Products (Name, Price, CategoryId) 
                SELECT 'Car Oil', 19.99, Id FROM Categories WHERE Slug = 'automotive';
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM Products WHERE Name IN ('Smartphone', 'Washing Machine', 'Jeans', 'Programming in C#', 'Car Oil');
            ");
        }
    }
}
