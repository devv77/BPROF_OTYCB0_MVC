using Models;
using Repository;
using System;
using System.Linq;

namespace Logic
{
    public class LeagueLogic
    {
        IRepository<Driver> driverrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;

        public LeagueLogic(IRepository<Driver> driverrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.teamrepo = teamrepo;
            this.driverrepo = driverrepo;
            this.leaguerepo = leaguerepo;
        }

        public void AddLeague(League league)
        {
            this.leaguerepo.AddItem(league);
        }

        public void DeleteLeague(string LeagueID)
        {
            this.leaguerepo.Delete(LeagueID);
        }


        public IQueryable<League> GetLeagues()
        {
            return leaguerepo.Search();
        }

        public League GetLeague(string LeagueID)
        {
            return leaguerepo.Search(LeagueID);
        }

        public void UpdateLeague(string oldLeague, League newLeague)
        {

            leaguerepo.Update(oldLeague, newLeague);
        }


    }
}
