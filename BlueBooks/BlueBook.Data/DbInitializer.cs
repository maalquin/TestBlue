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
        public static void  Seed(IApplicationBuilder applicationBuilder)
        {
            BlueBookDBContext context = applicationBuilder.ApplicationServices.GetRequiredService<BlueBookDBContext>();

            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = applicationBuilder.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();




            // Add Lender
            var user = new IdentityUser() { UserName = "maalquin", Email = "maalquin@hotmail.com", EmailConfirmed = true };
            userManager.CreateAsync(user, "%Quintero86*");

            if (roleManager.Roles.Count() == 0)
            {
                var role = new IdentityRole("Admin");
                roleManager.CreateAsync(role);
                
            }

            //var adminUser = userManager.FindByNameAsync("maalquin").Result;
            //var rolex = roleManager.FindByNameAsync("Admin").Result;
            

            //userManager.AddToRoleAsync(adminUser,rolex.Name);



            // Add Author
            var authorDeErnest = new Author
            {
                Name = "Ernest hemingway",
                Books = new List<Book>()
                {
                    new Book { Title = "El viejo y el Mar" },
                    new Book { Title = "Adios a las Armas" }
                }
            };

            var authorGabo = new Author
            {
                Name = "Gabriel Garcia Marquez",
                Books = new List<Book>()
                {
                    new Book { Title = "Cien Años de Soledad"},
                    new Book { Title = "El Coronel no tiene quien le "},
                    new Book { Title = "La hojarasca"}
                }
            };

            context.Authors.Add(authorDeErnest);
            context.Authors.Add(authorGabo);

            context.SaveChanges();
        }
    }
   
}
