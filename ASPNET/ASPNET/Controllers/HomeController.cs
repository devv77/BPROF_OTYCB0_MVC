using Data;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET.Controllers
{
    public class HomeController : Controller
    {
        LeagueLogic leagueLogic;
        DriverLogic driverLogic;
        TeamLogic teamLogic;
        public HomeController(LeagueLogic lealo, TeamLogic teamlo, DriverLogic driverlo)
        {
            this.leagueLogic = lealo;
            this.teamLogic = teamlo;
            this.driverLogic = driverlo;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult LeagueAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LeagueAdd(League league)
        {
            league.LID = Guid.NewGuid().ToString();
            leagueLogic.AddLeague(league);
            return RedirectToAction(nameof(LeagueList));
        }
        public IActionResult LeagueList()
        {            
            return View(leagueLogic.GetLeagues());
        }
        [HttpGet]
        public IActionResult TeamAdd(string id)
        {
            return View(nameof(TeamAdd),id);
        }
        [HttpPost]
        public IActionResult TeamAdd(Team team, string id)
        {
            team.LID = id;
            team.TID = Guid.NewGuid().ToString();
            teamLogic.AddTeam(team);
            return RedirectToAction(nameof(TeamList));
        }
        public IActionResult TeamList()
        {
            return View(teamLogic.GetAllTeam());
        }
        [HttpGet]
        public IActionResult DriverAdd(string id)
        {
            return View(nameof(DriverAdd),id);
        }
        [HttpPost]
        public IActionResult DriverAdd(string id, Driver driver)
        {
            driver.TID = id;
            driver.DID = Guid.NewGuid().ToString();
            driverLogic.AddDriver(driver);
            return View(nameof(LeagueList), id);
        }

    }
}
