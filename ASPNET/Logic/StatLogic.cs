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
        public StatLogic(TeamLogic tl, LeagueLogic ll)
        {
            teamLogic = tl;
            leagueLogic = ll;
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
            var t111 = teamLogic.GetAllTeam();
            var d111 = driverLogic.GetDrivers();
            var oldTeam= (from x in teamLogic.GetAllTeam().ToList()                                                        
                            orderby x.Created ascending
                            select x).FirstOrDefault();
            var oldestteamdrivers = (from x in driverLogic.GetDrivers().ToList()
                                     where x.TID == oldTeam.TID
                                     select x).ToList();                                                                                        



            /*
            var oldTeamD = (from x in teamLogic.GetAllTeam().ToList()                            
                            join y in driverLogic.GetDrivers().ToList()
                            on x.TID equals y.TID
                            orderby x.Created ascending
                            select x.Drivers).FirstOrDefault().ToList();

            */
            return oldestteamdrivers;
        }




        public int MostDriverInTeam()
        {

            var MDIT = (from x in teamLogic.GetAllTeam().ToList()
                        join y in driverLogic.GetDrivers().ToList()
                        on x.TID equals y.TID
                        group y by x.TID into g
                        orderby g.Count() descending
                        select g.Count()).FirstOrDefault();
            return MDIT;
        }

        public List<Team> TeamOfBestLeague()
        {
            var bestleagues = (from x in leagueLogic.GetLeagues().ToList()
                               orderby x.Rating descending
                               select x).FirstOrDefault();


            var TBL = (from x in teamLogic.GetAllTeam().ToList()
                       where x.LID == bestleagues.LID
                       orderby x.TName ascending
                       select x).ToList();                       

            return TBL;
        }



        public string MostUsedEngine()
        {

            var abcd = (from x in teamLogic.GetAllTeam().ToList()
                       group x by x.Engine into g
                       orderby g.Count() descending
                       select new
                       {
                           _name = g.Key,
                           _count = g.Count()
                       });

            var EAD = abcd.FirstOrDefault();

            string output = "";
            output += EAD._name.ToString()+" "+ EAD._count.ToString();

            return output;
        }



    }
}
