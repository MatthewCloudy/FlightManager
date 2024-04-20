using FlightManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.DataAccess.Abstractions
{
    public interface IAirportRepository
    {
        ICollection<Airport> GetAll();
        Airport? GetByName(string name);
    }
}
