using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnixWebApi.Models;

namespace UnixWebApi
{
    public class UnixDbContext : DbContext
    {
        public UnixDbContext(DbContextOptions<UnixDbContext> options) :base(options)
        {

        }

        public DbSet<Gyarto> Gyartok { get; set; }
        public DbSet<Modell> Modellek { get; set; }
        public DbSet<Reszletek> Reszletek { get; set; }
    }
}
