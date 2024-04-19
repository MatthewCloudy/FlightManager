using Microsoft.AspNetCore.Mvc;
using FlightManager.DataAccess.Repositories;
using FlightManager.DataAccess.Abstractions;
using FlightManager.Domain.Models;
using FlightManager.Api.Models;

namespace FlightManager.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightRepository _flightRepository;

        public FlightsController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
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
                //_flightRepository.Add(flightRequest);
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

        [HttpPut("{id}")]
        public IActionResult EditFlight([FromRoute] int id, [FromBody] Flight flight)
        {
            try
            {
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

