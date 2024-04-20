using Microsoft.AspNetCore.Mvc;
using FlightManager.DataAccess.Repositories;
using FlightManager.DataAccess.Abstractions;
using FlightManager.Domain.Models;
using FlightManager.Api.Models;
using System.Globalization;
using FlightManager.Api.Services;

namespace FlightManager.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IAirportRepository _airportRepository;

        public FlightsController(IFlightRepository flightRepository, 
            IAirplaneRepository airplaneRepository, IAirportRepository airportRepository)
        {
            _flightRepository = flightRepository;
            _airplaneRepository = airplaneRepository;
            _airportRepository = airportRepository;
        }

        [HttpGet]
        public IActionResult GetAllFlights()
        {
            try
            {
                var flights = _flightRepository.GetAll();
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] FlightPostRequest flightRequest)
        {
            try
            {
                Flight flight = new createFlightPost().Create(_airportRepository, _airplaneRepository, flightRequest);
                _flightRepository.Add(flight);

                return Ok("Flight added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFlight([FromRoute] int id)
        {
            try
            {
                _flightRepository.Delete(id);
                return Ok("Flight deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult EditFlight([FromRoute] int id, [FromBody] FlightPostRequest flightRequest)
        {
            try
            {
                Flight flight = new createFlightPatch().Create(_airportRepository, _airplaneRepository, flightRequest);

                _flightRepository.Edit(id, flight);
                return Ok("Flight edited successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}

