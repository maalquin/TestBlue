using BlueBook.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueBook.Data
{
    public class DbInitializer
    {
        public static async Task  Seed(IApplicationBuilder applicationBuilder)
        {
            BlueBookDBContext context = applicationBuilder.ApplicationServices.GetRequiredService<BlueBookDBContext>();

            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = applicationBuilder.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();
            
            
            var user = new IdentityUser() { UserName = "maalquin", Email = "maalquin@hotmail.com", EmailConfirmed = true };


            await userManager.CreateAsync(user, "%Quintero86*");

            if (roleManager.Roles.Count() == 0)
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
                
            }




            if (context.Authors.Count() == 0)
            {
                //var catetoryOpera = new Category
                //{
                //    Id = 1,
                //    Categoryname = "Novela"
                //};
                //var catetoryFiction = new Category
                //{
                //    Id = 2,
                //    Categoryname = "Fiction"
                //};
                //var catetoryDrame = new Category
                //{
                //    Id = 3,
                //    Categoryname = "Dramaturgy"
                //};
                
                // Add Author
                var authorDeErnest = new Author
                {
                    Name = "Ernest hemingway",
                    Books = new List<Book>()
 
                    
                {
                    new Book { Title = "El viejo y el Mar", Category = new Category() {  Categoryname = "Drama" } },
                    new Book { Title = "Adios a las Armas", Category = new Category() {  Categoryname = "Opera" } }
                }
                };

                var authorGabo = new Author
                {
                    Name = "Gabriel Garcia Marquez",
                    Books = new List<Book>()
                {
                    new Book { Title = "Cien Años de Soledad", Category = new Category() { Categoryname = "Cuento" } },
                    new Book { Title = "El Coronel no tiene quien le ", Category = new Category() {  Categoryname = "Soledad" } },
                    new Book { Title = "La hojarasca", Category = new Category() { Categoryname = "Novela" }}
                }
                };

        
                context.Authors.Add(authorDeErnest);
                context.Authors.Add(authorGabo);
            }

            context.SaveChanges();
        }
    }
   
}
