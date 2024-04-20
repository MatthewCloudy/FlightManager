using FlightManager.Domain.Models;

namespace FlightManager.Api.Models
{
    public class FlightPostRequest
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public string Airplane { get; set; }
        public string Name {  get; set; }
        public string DepartureTime { get; set; }
    }
}
