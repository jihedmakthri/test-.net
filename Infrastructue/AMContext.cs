
using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Infrastructue.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure
{
    public class AMContext: DbContext
    {

        //public DbSet<Plane> Planes { get; set; }
        //public DbSet<Flight> Flights { get; set; }
        //public DbSet<Passenger> Passengers { get; set; }
        //public DbSet<Staff> Staff { get; set; }
        //public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Citoyen> Citoyen { get; set; }
        public DbSet<Vaccin> Vaccin { get; set; }
        public DbSet<CentreVaccination> CentreVaccination { get; set; }
        public DbSet<RendezVous> RendezVous { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=TestDB;MultipleActiveResultSets=true;Integrated Security=true") ;
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RendezVousConfiguration());
            modelBuilder.ApplyConfiguration(new CitoyenConfiguration()); 
            //modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            //modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            //modelBuilder.ApplyConfiguration(new TicketConfiguration());

            //modelBuilder.Entity<Staff>().ToTable("Staff");
            //modelBuilder.Entity<Traveller>().ToTable("Travellers");
            //foreach (var p in modelBuilder.Model //q4a
            //    .GetEntityTypes()
            //    .SelectMany(a => a.GetProperties())
            //    .Where(t=>t.ClrType == typeof(string)))
            //    {
            //        p.IsNullable = false;
            //    }
                

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        //    // Pre-convention model configuration goes here
        //    configurationBuilder
        //        .Properties<string>()
        //        .HaveMaxLength(50);
        //configurationBuilder
        //    .Properties<decimal>()
        //        .HavePrecision(8,3);
            //configurationBuilder
            //  .Properties<DateTime>()
            //      .HaveColumnType("date");
            
        }



    }
}
