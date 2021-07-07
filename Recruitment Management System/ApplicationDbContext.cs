using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RMSLibrary.Models;
using RMSLibrary.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment_Management_System
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }
            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
            }

            public DbSet<ProfilAplikanta> ProfilAplikanta { get; set; }
            public DbSet<Aplikacija> Aplikacija { get; set; }
            public DbSet<ProfilKompanije> ProfilKompanije { get; set; }
            public DbSet<ProfilAdministratora> ProfilAdministratora { get; set; }
            public DbSet<Adresa> Adresa { get; set; }
            public DbSet<Lokacija> Lokacija { get; set; }
            public DbSet<OglasiTable> OglasiTable { get; set; }
            public DbSet<Obrazovanje> Obrazovanje { get; set; }
            public DbSet<Vjestine> Vjestine { get; set; }
            public DbSet<RadnoIskustvo> RadnoIskustvo { get; set; }
            public DbSet<Status> Status { get; set; }
            public DbSet<RefreshToken> RefreshToken { get; set; }
            public DbSet<GetUserById> GetUserByIds { get; set; }
    }
}
