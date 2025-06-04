using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // This imports DbContext, DbSet, ModelBuilder, etc.
using animomentapi.Data; // Add this to access your TShirts and ProductCategory classes
using animomentapi.Models; 
//using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace animomentapi.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions): base(dbContextOptions)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        //This tells EF Core: Table name: TShirts Schema: Ani
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // List<IdentityRole> roles = new List<IdentityRole>{
            //     new IdentityRole{
            //         Name = "Admin",
            //         NormalizedName = "ADMIN"
            //     },
            //     new IdentityRole{
            //         Name = "User",
            //         NormalizedName = "USER"
            //     }
            // };
            // modelBuilder.Entity<IdentityRole>().HasData(roles);

            //modelBuilder.Entity<User>().ToTable("User", schema: "Ani");
            //modelBuilder.Entity<Cart>().ToTable("Cart", schema: "Ani");
            //modelBuilder.Entity<CartItem>().ToTable("CartItem", schema: "Ani");
            //modelBuilder.Entity<Product>().ToTable("Product", schema: "Ani");
            //modelBuilder.Entity<Product>().HasIndex(p => p.article_number).IsUnique();
            //modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory", schema: "Ani");
        }
    }
}

//dotnet ef database drop
//dotnet ef database update
//dotnet ef migrations add name
//dotnet ef database update
//dotnet watch run