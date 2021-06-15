using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Driver")]
    public class DriverController: ControllerBase
    {
        DriverLogic logic;
        public DriverController(DriverLogic logic)
        {
            this.logic = logic;
        }

        // localhost:6666/driver/uid
        [HttpDelete("{uid}")]
        public void DeleteDriver(string uid)
        {
            logic.DeleteDriver(uid);
        }

        [HttpGet("{uid}")]
        public Driver GetDriver(string uid)
        {
            return logic.GetDriver(uid);
        }

        //Ez egy automatikus JSON lesz a végén az API miatt
        [HttpGet]
        public IEnumerable<Driver> GetAllDriver()
        {
            return logic.GetDrivers();
        }

        [HttpPost]
        public void AddDriver([FromBody]Driver item)
        {
            logic.AddDriver(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateDriver(string oldid, [FromBody] Driver item)
        {
            logic.UpdateDriver(oldid, item);
        }
    }
}
