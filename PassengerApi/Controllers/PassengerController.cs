using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PassengerApi.Model;

namespace PassengerApi.Controllers
{
    [Route("api")]
    [ApiExplorerSettings(GroupName = "Passenger")]
    public class PassengerController : Controller
    {

        [HttpGet, Route("Passenger")]
        public List<Passenger> Get()
        {
            return PassengerDataRepository.GetAll();
        }

        [HttpGet, Route("Passenger/{id}")]
        public Passenger Get(int id)
        {
            return PassengerDataRepository.GetPassengerById(id);
        }
    }
}
