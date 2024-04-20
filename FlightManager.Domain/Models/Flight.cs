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
        public Flight()
        {
            
        }
        public Flight(int Id, string Name, DateTime DepartureTime, Airport DepartureCity, Airport ArrivalCity, Airplane Airplane)
        {
            this.Id = Id;
            this.Name = Name;
            this.DepartureTime = DepartureTime;
            this.DepartureCity = DepartureCity;
            this.ArrivalCity = ArrivalCity;
            this.Airplane = Airplane;
        }

        public Flight(string Name, DateTime DepartureTime, Airport DepartureCity, Airport ArrivalCity, Airplane Airplane)
        {
            this.Name = Name;
            this.DepartureTime = DepartureTime;
            this.DepartureCity = DepartureCity;
            this.ArrivalCity = ArrivalCity;
            this.Airplane = Airplane;
        }

    }
}
