using FlightManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FlightManager.DataAccess.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ) : base(options)
        { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasOne(i => i.DepartureCity)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Flight>()
                .HasOne(i => i.ArrivalCity)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
