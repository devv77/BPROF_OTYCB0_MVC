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
    [ApiController]
    [Route("{controller}")]
    public class EditController : ControllerBase
    {
        DriverLogic dlogic;
        TeamLogic tlogic;
        LeagueLogic llogic;

        public EditController(DriverLogic dlogic, TeamLogic tlogic, LeagueLogic llogic)
        {
            this.dlogic = dlogic;
            this.tlogic = tlogic;
            this.llogic = llogic;
        }

        [HttpGet]
        public void FillDb()
        {
            //HomeControllerből átillesztett kód! 
            League lg1 = new League { Name = "Formula 1 (F1)", Rating = 10, Homology = true, RaceTypes = RaceType.circuit };
            llogic.AddLeague(lg1);
            League lg2 = new League { Name = "Deutsche Tourenwagen Masters (DTM)", Rating = 5, Homology = false, RaceTypes = RaceType.circuit };
            llogic.AddLeague(lg2);
            League lg3 = new League { Name = "World Touring Car Championship (WTCC)", Rating = 7, Homology = false, RaceTypes = RaceType.circuit };
            llogic.AddLeague(lg3);
            League lg4 = new League { Name = "Le Mans Series", Rating = 8, Homology = false, RaceTypes = RaceType.circuit };
            llogic.AddLeague(lg4);
            League lg5 = new League { Name = "Formula E", Rating = 3, Homology = true, RaceTypes = RaceType.circuit };
            llogic.AddLeague(lg5);
            League lg6 = new League { Name = "World of Outlaws Sprint Car Series", Rating = 5, Homology = false, RaceTypes = RaceType.sprint };
            llogic.AddLeague(lg6);
            /*------------------------------------------------------------------------*/
            Team tm1 = new Team { TName = "Mercedes-AMG Petronas F1 Team", Created = 2010, Country = "Germany", Engine = ESuppliers.Mercedes, LID = lg1.LID };
            tlogic.AddTeam(tm1);
            Team tm2 = new Team { TName = "Aston Martin Red Bull Racing", Created = 2005, Country = "Austria", Engine = ESuppliers.Honda, LID = lg1.LID };
            tlogic.AddTeam(tm2);
            Team tm3 = new Team { TName = "Renault DP World F1 Team", Created = 1977, Country = "France", Engine = ESuppliers.Renault, LID = lg1.LID };
            tlogic.AddTeam(tm3);
            Team tm4 = new Team { TName = "Audi MotorSport Abt Sportsline", Created = 1991, Country = "Germany", Engine = ESuppliers.Audi, LID = lg2.LID };
            tlogic.AddTeam(tm4);
            Team tm5 = new Team { TName = "Zengő Motorsport Services KFT", Created = 1996, Country = "Hungary", Engine = ESuppliers.Seat, LID = lg3.LID };
            tlogic.AddTeam(tm5);
            Team tm6 = new Team { TName = "DragonSpeed Racing", Created = 2007, Country = "USA", Engine = ESuppliers.Gibson, LID = lg4.LID };
            tlogic.AddTeam(tm6);
            Team tm7 = new Team { TName = "Alfa Romeo Racing Orlen", Created = 2019, Country = "Switzerland", Engine = ESuppliers.Ferrari, LID = lg1.LID };
            tlogic.AddTeam(tm7);
            Team tm8 = new Team { TName = "McLaren-Renault", Created = 1963, Country = "Switzerland", Engine = ESuppliers.Renault, LID = lg1.LID };
            tlogic.AddTeam(tm8);
            /*------------------------------------------------------------------------*/
            Driver dr1 = new Driver { DName = "Valtteri Bottas", BornYear = 1989, CountryB = "Finland", RaceNumber = 77, TID = tm1.TID };
            dlogic.AddDriver(dr1);
            Driver dr2 = new Driver { DName = "Daniel Ricciardo", BornYear = 1989, CountryB = "Australia", RaceNumber = 3, TID = tm3.TID };
            dlogic.AddDriver(dr2);
            Driver dr3 = new Driver { DName = "Max Verstappen", BornYear = 1997, CountryB = "Belgium", RaceNumber = 33, TID = tm2.TID };
            dlogic.AddDriver(dr3);
            Driver dr4 = new Driver { DName = "Lucas di Grassi", BornYear = 1984, CountryB = "Brazil", RaceNumber = 11, TID = tm4.TID };
            dlogic.AddDriver(dr4);
            Driver dr5 = new Driver { DName = "Boldizs Bence", BornYear = 1997, CountryB = "Hungary", RaceNumber = 55, TID = tm5.TID };
            dlogic.AddDriver(dr5);
            Driver dr6 = new Driver { DName = "Ben Hanley", BornYear = 1985, CountryB = "England", RaceNumber = 27, TID = tm6.TID };
            dlogic.AddDriver(dr6);
            Driver dr7 = new Driver { DName = "Esteban Ocon", BornYear = 1996, CountryB = "France", RaceNumber = 31, TID = tm3.TID };
            dlogic.AddDriver(dr7);
            Driver dr8 = new Driver { DName = "Kimi Räikkönen", BornYear = 1979, CountryB = "Finland", RaceNumber = 7, TID = tm7.TID };
            dlogic.AddDriver(dr8);
            Driver dr9 = new Driver { DName = "Lando Norris", BornYear = 1999, CountryB = "England", RaceNumber = 4, TID = tm8.TID };
            dlogic.AddDriver(dr9);
            Driver dr10 = new Driver { DName = "Carlos Sainz Jr.", BornYear = 1994, CountryB = "Spain", RaceNumber = 55, TID = tm8.TID };
            dlogic.AddDriver(dr10);
            Driver dr11 = new Driver { DName = "Paul Di Resta", BornYear = 1986, CountryB = "England", RaceNumber = 40, TID = tm8.TID };
            dlogic.AddDriver(dr11);

        }
        
        
        [HttpPost]
        public void AddDriverToTeam([FromBody] DriverAndTeam item)
        {
            tlogic.AddDriverToTeam(dlogic.GetDriver(item.DriverUid), item.TeamUid);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public void RemoveDriverFromTeam([FromBody] DriverAndTeam item)
        {
            tlogic.RemoveDriverFromTeam(dlogic.GetDriver(item.DriverUid), item.TeamUid);
        }


    }
}
