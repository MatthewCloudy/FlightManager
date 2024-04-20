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
    public class AirplaneRepository : IAirplaneRepository
    {
        private readonly DataContext _context;
        public AirplaneRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Airplane> GetAll()
        {
            return _context.Airplanes.ToList();
        }

        public Airplane? GetByName(string name)
        {
            return _context.Airplanes.FirstOrDefault(a => a.Name == name);
        }
    }
}
