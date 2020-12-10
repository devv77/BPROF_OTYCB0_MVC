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

    }
}
