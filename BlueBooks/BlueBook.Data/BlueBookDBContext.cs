using BlueBook.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueBook.Data
{
    public class BlueBookDBContext : IdentityDbContext<IdentityUser>
    {
        public BlueBookDBContext(DbContextOptions<BlueBookDBContext> options) : base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           // builder.Entity<Book>();
               

            // https://github.com/aspnet/EntityFrameworkCore/issues/3924
            // EF Core 2 doesnt support Cascade on delete for in Memory Database

            base.OnModelCreating(builder);
           

        
    }
    }
}
