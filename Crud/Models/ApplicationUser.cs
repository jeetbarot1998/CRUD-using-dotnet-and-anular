using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    [NotMapped]
    public class ApplicationUser: IdentityUser
    {
        [Column(TypeName ="nvarchar(25)")]
        public string FullName { get; set; }

        //public string Discriminator = "ApplicationUser";

    }
}
