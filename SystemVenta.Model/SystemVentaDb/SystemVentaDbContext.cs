using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SystemVenta.Model.Entities;

namespace SystemVenta.Model.SystemVentaDb
{
   
        public class SystemVentaDbContext : DbContext
    {
        public SystemVentaDbContext(DbContextOptions<SystemVentaDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Billing> Billings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

}
