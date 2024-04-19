using Microsoft.AspNetCore.Mvc;

using FlightManager.Domain.Models;

namespace FlightManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};


        public FlightController()
        {
            
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Flight>> Get()
        //{
        //    //try
        //    //{
        //    //    var connections = _unitOfWork.Connection.GetAll(c => (c.From.Id == request.StartStationId &&
        //    //        c.Destination.Id == request.EndStationId &&
        //    //        c.DepartureTime >= request.DepartureTime));

        //    //    if (connections.Count() == 0)
        //    //    {
        //    //        return NotFound();
        //    //    }

        //    //    return Ok(connections);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return BadRequest(ex.Message);
        //    //}
        //}
    }
}
