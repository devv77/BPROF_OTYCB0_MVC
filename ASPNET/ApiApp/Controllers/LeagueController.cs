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
    [Route("League")]
    public class LeagueController
    {
        LeagueLogic logic;
        public LeagueController(LeagueLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteLeague(string uid)
        {
            logic.DeleteLeague(uid);
        }

        [HttpGet("{uid}")]
        public League GetLeague(string uid)
        {
            return logic.GetLeague(uid);
        }

        //Ez egy automatikus JSON lesz a végén az API miatt
        [HttpGet]
        public IEnumerable<League> GetAllLeagues()
        {
            return logic.GetLeagues();
        }

        [HttpPost]
        public void AddLeague([FromBody] League item)
        {
            logic.AddLeague(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateLeague(string oldid, [FromBody] League item)
        {
            logic.UpdateLeague(oldid, item);
        }
    }
}
