using Entity.Entities.Contacts;
using Entity.Entities.Countries;
using Entity.Entities.Service;
using Entity.Entities.Tariffs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concret
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=;Database=Starex;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<CountryContact> CountryContacts { get; set; }
    }
}
