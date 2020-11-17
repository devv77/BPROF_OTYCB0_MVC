using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class TeamLogic
    {
        IRepository<Driver> Driverrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;

        public TeamLogic(IRepository<Driver> Driverrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.Driverrepo = Driverrepo;
            this.leaguerepo = leaguerepo;
            this.teamrepo = teamrepo;
        }


        public void AddTeam(Team team)
        {
            this.teamrepo.AddItem(team);

        }

        public void DeleteTeam(Team team)
        {
            this.teamrepo.Delete(team);

        }

        public IQueryable<Team> GetAllTeam()
        {
            return teamrepo.Search();
        }

        public Team GetTeam(string TeamID)
        {
            return teamrepo.Search(TeamID);
        }

        public void UpdateTeam(string oldteam, Team newteam)
        {
            teamrepo.Update(oldteam, newteam);
        }
    }
}
