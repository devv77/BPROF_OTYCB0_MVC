using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DriversRepository : IRepository<Driver>
    {
        DriversDbContext context = new DriversDbContext();
        public void AddItem(Driver item)
        {
            context.Drivers.Add(item);
            context.SaveChanges();
        }

        public void Delete(Driver item)
        {
            context.Drivers.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string DID)
        {
            Delete(Search(DID));
        }

        public Driver Search(string DID)
        {
            return context.Drivers.FirstOrDefault(q => q.DID == DID);
        }

        public IQueryable<Driver> Search()
        {
            return context.Drivers.AsQueryable(); 
        }

        public void Update(string oldid, Driver newitem)
        {
            var olditem = Search(oldid);
            olditem.DName = newitem.DName;
            olditem.CountryB = newitem.CountryB;
            olditem.BornYear = newitem.BornYear;
            olditem.OwnTeam = newitem.OwnTeam;
            olditem.RaceNumber = newitem.RaceNumber;                        
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
