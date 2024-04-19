using FlightManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.DataAccess.Abstractions
{
    public interface IFlightRepository
    {
        ICollection<Flight> GetAll();
        void Add(Flight flight);
        void Delete(int id);
        void Edit(int id, Flight flight);
    }
}
