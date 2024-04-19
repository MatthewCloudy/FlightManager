using FlightManager.DataAccess.Abstractions;
using FlightManager.DataAccess.Data;
using FlightManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.DataAccess.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DataContext _context;
        public FlightRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(Flight flight)
        {
            _context.Flights.Add(flight);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var flightToRemove = _context.Flights.Find(id);
            if (flightToRemove != null)
            {
                _context.Flights.Remove(flightToRemove);
                _context.SaveChanges();
            }
        }

        public void Edit(int id, Flight flight)
        {
            var existingFlight = _context.Flights.Find(id);
            if (existingFlight == null)
            {
                return;
            }

            _context.Entry(existingFlight).CurrentValues.SetValues(flight);
            _context.SaveChanges();
        }

        public ICollection<Flight> GetAll()
        {
            return _context.Flights.Include(f => f.DepartureCity)
                              .Include(f => f.ArrivalCity)
                              .Include(f => f.Airplane)
                              .ToList();
        }
    }
}
