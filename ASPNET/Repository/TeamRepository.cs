using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class TeamRepository : IRepository<Team>
    {
        DriversDbContext context = new DriversDbContext();
        public void AddItem(Team item)
        {
            context.Teams.Add(item);
            context.SaveChanges();
        }

        public void Delete(Team item)
        {
            context.Teams.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string TID)
        {
            Delete(Search(TID));
        }

        public IQueryable<Team> Search()
        {
            return context.Teams.AsQueryable();
        }

        public Team Search(string TID)
        {
            return context.Teams.FirstOrDefault(q => q.TID == TID);
        }

        public void Update(string oldid, Team newitem)
        {
            var olditem = Search(oldid);
            olditem.TName = newitem.TName;
            olditem.Country = newitem.Country;
            olditem.Drivers.Clear();
            foreach (var item in newitem.Drivers)
            {
                olditem.Drivers.Add(item);
            }
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
