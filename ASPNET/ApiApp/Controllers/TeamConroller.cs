using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class TeamConroller
    {
        TeamLogic logic;
        public TeamConroller(TeamLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteTeam(string uid)
        {
            logic.DeleteTeam(uid);
        }

        [HttpGet("{uid}")]
        public Team GetTeam(string uid)
        {
            return logic.GetTeam(uid);
        }

        //Ez egy automatikus JSON lesz a végén az API miatt
        [HttpGet]
        public IEnumerable<Team> GetAllTeam()
        {
            return logic.GetAllTeam();
        }

        [HttpPost]
        public void AddTeam([FromBody] Team item)
        {
            logic.AddTeam(item);
        }

        [HttpPut("{oldid}")]
        public void UpdateTeam(string oldid, [FromBody] Team item)
        {
            logic.UpdateTeam(oldid, item);
        }
    }
}
