using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class LeagueRepository : IRepository<League>
    {
        DriversDbContext context = new DriversDbContext();
        public void AddItem(League item)
        {
            context.Leagues.Add(item);
            context.SaveChanges();
        }

        public void Delete(League item)
        {
            context.Leagues.Remove(item);
            context.SaveChanges();
        }

        public void Delete(string LID)
        {
            Delete(Search(LID));
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public League Search(string LID)
        {
            return context.Leagues.FirstOrDefault(q => q.LID == LID);
        }

        public IQueryable<League> Search()
        {
            return context.Leagues.AsQueryable();
        }
        

        public void Update(string oldid, League newitem)
        {
            var oldleague = Search(oldid);
            oldleague.Name = newitem.Name;
            oldleague.Teams.Clear();
            foreach(var item in newitem.Teams)
            {
                oldleague.Teams.Add(item);
            }

            context.SaveChanges();
        }
    }
}
