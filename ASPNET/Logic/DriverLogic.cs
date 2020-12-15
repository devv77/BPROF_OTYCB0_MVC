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


        public void AddDriver(Driver Driver)
        {
            this.driverrepo.AddItem(Driver);

        }

        public void DeleteDriver(string id)
        {
            this.driverrepo.Delete(id);
        }

        public IQueryable<Driver> GetDrivers()
        {
            return driverrepo.Search();
        }

        public IQueryable<Driver> GetDriversOfTeam(string id)
        {
            var drivers = from q in driverrepo.Search()
                          where q.TID == id
                          select q;
            return drivers;
        }


        public Driver GetDriver(string DID)
        {
            return driverrepo.Search(DID);
        }


        public void UpdateDriver(string DID, Driver newdriver)
        {
            driverrepo.Update(DID, newdriver);
        }


    }
}
