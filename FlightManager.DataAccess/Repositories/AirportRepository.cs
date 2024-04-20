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
    public class AirportRepository : IAirportRepository
    {
        private readonly DataContext _context;
        public AirportRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Airport> GetAll()
        {
            return _context.Airports.ToList();
        }

        public Airport? GetByName(string name)
        {
            return _context.Airports.FirstOrDefault(a => a.Name == name);
        }
    }
}
