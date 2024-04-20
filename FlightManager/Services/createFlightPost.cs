using FlightManager.Api.Models;
using FlightManager.DataAccess.Abstractions;
using FlightManager.Domain.Models;
using System.Globalization;

namespace FlightManager.Api.Services
{

    public class createFlightPost
    {
        public createFlightPost() { }
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
            var departureTime = DateTime.ParseExact(flightRequest.DepartureTime, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);

            return new Flight(flightRequest.Name, departureTime, departureCity, arrivalCity, airplane);
        }
    }
}
