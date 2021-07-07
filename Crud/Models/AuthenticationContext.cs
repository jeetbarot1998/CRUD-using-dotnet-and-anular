using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{   // IdentityDbContext Base class for the Entity Framework database context used for identity.
    //These services include services like the UserStore service and the SignInManager.
    //We need to inject both of these services into our controller.
    //With this, we can call the appropriate APIs when we need to create a user or sign in a user.
    public class AuthenticationContext: IdentityDbContext <ApplicationUser>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {

                
        }
        [NotMapped]
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        // The ApplicationUser has "FullName" which is to be added additionally to the IdentityDbContext.

        //A DbSet represents the collection of all entities in the context, or that can be
        //queried from the database, of a given type. DbSet objects are created from a DbContext using the DbContext.
        //Set method.

    }
}
