using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Noliktava.Models;

namespace Noliktava.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Noliktava.Models.Prece> Prece { get; set; }
        public DbSet<Noliktava.Models.PardPrece> PardPrece { get; set; }
    }
}
