using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Repository;
using System.Linq;

namespace Logic
{
    public class StatLogic
    {
        public IRepository<League> repoLeague { get; set; }
        public IRepository<Team> repoTeam { get; set; }
        public IRepository<Driver> repoDriver { get; set; }
        public LeagueLogic leagueLogic { get; set; }
        public TeamLogic teamLogic { get; set; }
        public DriverLogic driverLogic { get; set; }
        public StatLogic(IRepository<Driver> driver, IRepository<Team> team, IRepository<League> league)
        {
            this.repoDriver = driver;
            repoTeam = team;
            repoLeague = league;
        }
        public StatLogic(LeagueLogic ll, TeamLogic tl, DriverLogic dl)
        {
            leagueLogic = ll;
            teamLogic = tl;
            driverLogic = dl;
        }
        public StatLogic(TeamLogic tl, DriverLogic dl)
        {
            teamLogic = tl;
            driverLogic = dl;
        }
        public StatLogic(IRepository<Driver> driver, IRepository<Team> team)
        {
            repoTeam = team;
            repoDriver = driver;
        }
        public StatLogic(IRepository<League> league, IRepository<Team> team)
        {
            repoLeague = league;
            repoTeam = team;
        }
        public StatLogic(IRepository<Team> team)
        {
            repoTeam = team;
        }
        public StatLogic()
        {

        }
        

        public List<Driver> OldestTeamDrivers()
        {
            var oldTeamD = (from x in teamLogic.GetAllTeam().ToList()                            
                            join y in driverLogic.GetDrivers().ToList()
                            on x.TID equals y.TID
                            orderby x.Created ascending
                            select x.Drivers).FirstOrDefault().ToList();
            return oldTeamD;
        }




        public int MostDriverInTeam()
        {

            var MDIT = (from x in teamLogic.GetAllTeam().ToList()
                        join y in driverLogic.GetDrivers().ToList()
                        on x.TID equals y.TID
                        orderby x.Drivers.Count descending
                        select x.Drivers.Count).FirstOrDefault();
            return MDIT;
        }

        public List<Team> TeamOfBestLeague()
        {

            var TBL = (from x in leagueLogic.GetLeagues().ToList()
                       join y in teamLogic.GetAllTeam().ToList()
                       on x.LID equals y.LID
                       group x by x.Rating into g
                       select new
                       {
                           _id = g.Key,
                           _teams = g.SelectMany(x => x.Teams).Distinct().ToList()
                       }).FirstOrDefault();
                       

            return TBL._teams;
        }



        public string MostUsedEngine()
        {

            var EAD = (from x in teamLogic.GetAllTeam().ToList()
                       group x by x.Engine into g
                       select new
                       {
                           _name = g.Key,
                           _count = g.Count()
                       }).FirstOrDefault();
            string output = "";
            output += EAD._name.ToString()+" "+ EAD._count.ToString();

            return output;
        }



    }
}
