using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class DriverLogic
    {

        IRepository<Driver> driverrepo;
        IRepository<Team> teamrepo;
        IRepository<League> leaguerepo;

        public DriverLogic(IRepository<Driver> driverrepo, IRepository<Team> teamrepo, IRepository<League> leaguerepo)
        {
            this.driverrepo = driverrepo;
            this.teamrepo = teamrepo;
            this.leaguerepo = leaguerepo;
        }


        public void AddPlayer(Driver player)
        {
            this.driverrepo.AddItem(player);

        }

        public void DeletePlayer(string IgazolasSzama)
        {
            this.driverrepo.Delete(IgazolasSzama);
        }

        public IQueryable<Driver> GetDrivers()
        {
            return driverrepo.Search();
        }


        public Driver GetPlayer(string DID)
        {
            return driverrepo.Search(DID);
        }


        public void UpdatePlayer(string DID, Driver newdriver)
        {
            driverrepo.Update(DID, newdriver);
        }


    }
}
