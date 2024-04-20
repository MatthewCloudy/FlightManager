using FlightManager.Api.Models;
using FlightManager.DataAccess.Abstractions;
using FlightManager.Domain.Models;

namespace FlightManager.Api.Services
{
    public class createFlightPatch
    {
        public createFlightPatch() { }

        public Flight Create(IAirportRepository airportRepository,
            IAirplaneRepository airplaneRepository, FlightPostRequest flightRequest)
        {
            Airport? departureCity = airportRepository.GetByName(flightRequest.DepartureCity);
            if (departureCity == null)
            {
                departureCity = new Airport(flightRequest.DepartureCity);
            }
            Airport? arrivalCity = airportRepository.GetByName(flightRequest.ArrivalCity);
            if (arrivalCity == null)
            {
                arrivalCity = new Airport(flightRequest.ArrivalCity);
            }
            Airplane? airplane = airplaneRepository.GetByName(flightRequest.Airplane);
            if (airplane == null)
            {
                airplane = new Airplane(flightRequest.Airplane);
            }
            var departureTime = DateTime.Parse(flightRequest.DepartureTime);

            return new Flight(flightRequest.Name, departureTime, departureCity, arrivalCity, airplane);
        }
    }
}
