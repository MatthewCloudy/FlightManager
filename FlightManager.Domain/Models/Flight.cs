using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Domain.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DepartureTime { get; set; }
        public Airport DepartureCity {  get; set; }
        public Airport ArrivalCity {  get; set; }
        public Airplane Airplane { get; set; }

    }
}
