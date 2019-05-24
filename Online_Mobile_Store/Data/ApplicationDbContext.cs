using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Mobile_Store.Models;

namespace Online_Mobile_Store.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
