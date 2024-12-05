using Microsoft.EntityFrameworkCore;
using VarsityPlug.Models;


namespace VarsityPlugApi.Contexts
{
    public class VPContext : DbContext
    {
        public VPContext(DbContextOptions dbCO) : base(dbCO) 
        {
        
        }    
        public DbSet<Product> PRODUCT { get; set; }
        public DbSet<Person> PERSON { get; set; }
        public DbSet<Cart> CART { get; set; }
        public DbSet<ProductCatagory> PRODUCTCATEGORY { get; set; }
        public DbSet<ProductSubCategory> PRODUCTSUBCATEGORY { get; set; }
        public DbSet<ProductImage> PRODUCTIMAGE { get; set; }
        public DbSet<ProductReview> PRODUCTREVIEW { get; set; }
        public DbSet<ProductRating> PRODUCTRATING { get; set; }
        public DbSet<Seller> SELLER { get; set; }
        public DbSet<Buyer> BUYER { get; set; }
    }
}
