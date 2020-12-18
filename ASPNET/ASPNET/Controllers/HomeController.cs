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
        /*----------------------------------------------------------*/
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
        public IActionResult LeagueEdit(string id)
        {
            return View(nameof(LeagueEdit), leagueLogic.GetLeague(id));
        }
        [HttpPost]
        public IActionResult LeagueEdit(League l)
        {
            leagueLogic.UpdateLeague(l.LID, l);
            return View(nameof(LeagueList), leagueLogic.GetLeagues());
        }
        /*----------------------------------------------------------*/
        [HttpGet]
        public IActionResult TeamAdd(string id)
        {
            return View(nameof(TeamAdd),id);
        }
        [HttpPost]
        public IActionResult TeamAdd(Team team)
        {            
            team.TID = Guid.NewGuid().ToString();
            teamLogic.AddTeam(team);
            return RedirectToAction(nameof(TeamList));
        }        
        public IActionResult AllTeamList()
        {
            return View(teamLogic.GetAllTeam());
        }
        public IActionResult TeamList(string id)
        {
            return View(teamLogic.GetTeamOfLeague(id));
        }
        [HttpGet]
        public IActionResult TeamEdit(string id)
        {
            return View(nameof(TeamEdit), teamLogic.GetTeam(id));
        }
        [HttpPost]
        public IActionResult TeamEdit(Team t)
        {
            teamLogic.UpdateTeam(t.LID, t);
            return View(nameof(TeamList), t.LID);
        }

        /*----------------------------------------------------------*/
        [HttpGet]
        public IActionResult DriverAdd(string id)
        {
            return View(nameof(DriverAdd),id);
        }
        [HttpPost]
        public IActionResult DriverAdd(Driver driver)
        {
            //driver.TID = id;
            //driver.TIDN = teamLogic.GetTeam(id).TName;
            driver.DID = Guid.NewGuid().ToString();            
            driverLogic.AddDriver(driver);
            driverLogic.UpdateDriver(driver.DID, driver);
            return RedirectToAction(nameof(TeamList));
        }
        public IActionResult DriverList()
        {
            return View(driverLogic.GetDrivers());
        }
        public IActionResult DriverList(string id)
        {
            return View(driverLogic.GetDriversOfTeam(id));
        }
        [HttpGet]
        public IActionResult DriverEdit(string id)
        {
            return View(nameof(DriverEdit), driverLogic.GetDriver(id));
        }
        [HttpPost]
        public IActionResult DriverEdit(Driver d)
        {
            driverLogic.UpdateDriver(d.TID, d);
            return View(nameof(DriverList), d.TID);
        }
        /*----------------------------------------------------------*/
        public IActionResult GenerateData()
        {
            League lg1 = new League { LID = Guid.NewGuid().ToString(), Name = "Formula 1 (F1)", Rating = 10, Homology = true, RaceTypes = RaceType.circuit };
            leagueLogic.AddLeague(lg1);
            League lg2 = new League { LID = Guid.NewGuid().ToString(), Name = "Deutsche Tourenwagen Masters (DTM)", Rating = 5, Homology = false, RaceTypes = RaceType.circuit };
            leagueLogic.AddLeague(lg2);
            League lg3 = new League { LID = Guid.NewGuid().ToString(), Name = "World Touring Car Championship (WTCC)", Rating = 7, Homology = false, RaceTypes = RaceType.circuit };
            leagueLogic.AddLeague(lg3);
            League lg4 = new League { LID = Guid.NewGuid().ToString(), Name = "Le Mans Series", Rating = 8, Homology = false, RaceTypes = RaceType.circuit };
            leagueLogic.AddLeague(lg4);
            League lg5 = new League { LID = Guid.NewGuid().ToString(), Name = "Formula E", Rating = 3, Homology = true, RaceTypes = RaceType.circuit };
            leagueLogic.AddLeague(lg5);
            League lg6 = new League { LID = Guid.NewGuid().ToString(), Name = "World of Outlaws Sprint Car Series", Rating = 5, Homology = false, RaceTypes = RaceType.sprint};
            leagueLogic.AddLeague(lg6);
            /*------------------------------------------------------------------------*/
            Team tm1 = new Team { TID = Guid.NewGuid().ToString(), TName = "Mercedes-AMG Petronas F1 Team", Created = 2010, Country = "Germany", Engine = ESuppliers.Mercedes, LID = lg1.LID };
            teamLogic.AddTeam(tm1);
            Team tm2 = new Team { TID = Guid.NewGuid().ToString(), TName = "Aston Martin Red Bull Racing", Created = 2005, Country = "Austria", Engine = ESuppliers.Honda, LID = lg1.LID };
            teamLogic.AddTeam(tm2);
            Team tm3 = new Team { TID = Guid.NewGuid().ToString(), TName = "Renault DP World F1 Team", Created = 1977, Country = "France", Engine = ESuppliers.Renault, LID = lg1.LID };
            teamLogic.AddTeam(tm3);
            Team tm4 = new Team { TID = Guid.NewGuid().ToString(), TName = "Audi MotorSport Abt Sportsline", Created = 1991, Country = "Germany", Engine = ESuppliers.Audi, LID = lg2.LID };
            teamLogic.AddTeam(tm4);
            Team tm5 = new Team { TID = Guid.NewGuid().ToString(), TName = "Zengő Motorsport Services KFT", Created = 1996, Country = "Hungary", Engine = ESuppliers.Seat, LID = lg3.LID };
            teamLogic.AddTeam(tm5);
            Team tm6 = new Team { TID = Guid.NewGuid().ToString(), TName = "DragonSpeed Racing", Created = 2007, Country = "USA", Engine = ESuppliers.Gibson, LID = lg4.LID };
            teamLogic.AddTeam(tm6);
            Team tm7 = new Team { TID = Guid.NewGuid().ToString(), TName = "Alfa Romeo Racing Orlen", Created = 2019, Country = "Switzerland", Engine = ESuppliers.Ferrari, LID = lg1.LID };
            teamLogic.AddTeam(tm7);
            Team tm8 = new Team { TID = Guid.NewGuid().ToString(), TName = "McLaren-Renault", Created = 1963, Country = "Switzerland", Engine = ESuppliers.Renault, LID = lg1.LID };
            teamLogic.AddTeam(tm8);
            /*------------------------------------------------------------------------*/
            Driver dr1 = new Driver { DID = Guid.NewGuid().ToString(), DName="Valtteri Bottas", BornYear=1989, CountryB="Finland", RaceNumber=77, TID=tm1.TID};
            driverLogic.AddDriver(dr1);
            Driver dr2 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Daniel Ricciardo", BornYear = 1989, CountryB = "Australia", RaceNumber = 3, TID = tm3.TID };
            driverLogic.AddDriver(dr2);
            Driver dr3 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Max Verstappen", BornYear = 1997, CountryB = "Belgium", RaceNumber = 33, TID = tm2.TID };
            driverLogic.AddDriver(dr3);
            Driver dr4 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Lucas di Grassi", BornYear = 1984, CountryB = "Brazil", RaceNumber = 11, TID = tm4.TID };
            driverLogic.AddDriver(dr4);
            Driver dr5 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Boldizs Bence", BornYear = 1997, CountryB = "Hungary", RaceNumber = 55, TID = tm5.TID };
            driverLogic.AddDriver(dr5);
            Driver dr6 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Ben Hanley", BornYear = 1985, CountryB = "England", RaceNumber = 27, TID = tm6.TID };
            driverLogic.AddDriver(dr6);
            Driver dr7 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Esteban Ocon", BornYear = 1996, CountryB = "France", RaceNumber = 31, TID = tm3.TID };
            driverLogic.AddDriver(dr7);
            Driver dr8 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Kimi Räikkönen", BornYear = 1979, CountryB = "Finland", RaceNumber = 7, TID = tm7.TID };
            driverLogic.AddDriver(dr8);
            Driver dr9 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Lando Norris", BornYear = 1999, CountryB = "England", RaceNumber = 4, TID = tm8.TID };
            driverLogic.AddDriver(dr9);
            Driver dr10 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Carlos Sainz Jr.", BornYear = 1994, CountryB = "Spain", RaceNumber = 55, TID = tm8.TID };
            driverLogic.AddDriver(dr10);
            Driver dr11 = new Driver { DID = Guid.NewGuid().ToString(), DName = "Paul Di Resta", BornYear = 1986, CountryB = "England", RaceNumber = 40, TID = tm8.TID };
            driverLogic.AddDriver(dr11);

            return RedirectToAction(nameof(Index));
        }

        

        

        public IActionResult Statistics()
        {
            StatLogic statLogic = new StatLogic(leagueLogic, teamLogic, driverLogic);
            Stat stat = new Stat();
            //Oldest team drivers stat

            stat.OldestTeamDrivers = statLogic.OldestTeamDrivers();

         
            stat.MostDriverInTeam=statLogic.MostDriverInTeam();

            /*----------------------------------------------------------------------*/
            //Most popular League and its teams

            stat.TeamsOfBestLeague=statLogic.TeamOfBestLeague();

            /*----------------------------------------------------------------------*/
            //Most used engine type and count

            stat.MostUsedEngine= statLogic.MostUsedEngine();            

            return View(stat);
        }




    }
}
