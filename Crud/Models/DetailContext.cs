using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Models
{
    public class DetailContext: DbContext
    {
        public DetailContext(DbContextOptions<DetailContext> options) : base(options)
        {

        }
        public DbSet<Detail> Details { get; set; }
    }
}
