using FlightManager.Domain.Models;

namespace FlightManager.Api.Models
{
    public class FlightPatchRequest
    {
        public string newDepartureCity { get; set; }
        public string newArrivalCity { get; set; }
        public string newAirplane { get; set; }
        public string newDepartureTime { get; set; }
    }
}
