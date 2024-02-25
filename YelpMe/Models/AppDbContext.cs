using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScrapeHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YelpMe.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("workstation id=ylpmsql.mssql.somee.com;packet size=4096;user id=yelpme1_SQLLogin_1;pwd=v6g3sy87a5;data source=ylpmsql.mssql.somee.com;persist security info=False;initial catalog=ylpmsql;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Business> Business { get; set; }

        public DbSet<Blocker> Blockers { get; set; }

        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Templates> Templates { get; set; }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Cloud> Clouds { get; set; }

        public DbSet<NameApiKeys> NameApiKeys { get; set; } 

        public DbSet<NameApiSettings> NameApiSettings { get; set; }

        public DbSet<WhatsAppIntergation> WhatsAppIntergations { get; set; }

        public DbSet<VerifyLogger> VerifyLoggers { get; set; }
    }
}
