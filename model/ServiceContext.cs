using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Assignment.model
{
    public class ServiceContext: DbContext
    {
        public DbSet<Senior_Citizen> senior_citizen { get; set; }
        public DbSet<Authentication> authentications { get; set; }
        public DbSet<ServicesByCity> services_by_city { get; set; }
        public DbSet<Care_Giver> care_givers { get; set; }
        public DbSet<ServicesAndSeniorCitizen> services_and_senior { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=divilok;Database=elder_careDB;Trusted_Connection=True;encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServicesAndSeniorCitizen>()
                .HasKey(k => new { k.serviceID, k.seniorCitizenID });

            modelBuilder.Entity<ServicesAndSeniorCitizen>()
                .HasOne(s => s.seniorCitizen)
                .WithMany(ss => ss.serviceAndSeniorCitizen)
                .HasForeignKey(k => k.seniorCitizenID);

            modelBuilder.Entity<ServicesAndSeniorCitizen>()
                .HasOne(s => s.cityServices)
                .WithMany(ss => ss.serviceAndSeniorCitizen)
                .HasForeignKey(k => k.serviceID);
        }
    }
}
