using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Stat
    {
        public List<Driver> OldestTeamDrivers;
        public int MostDriverInTeam { get; set; }
        public string MostUsedEngine { get; set; }
        public List<Team> TeamsOfBestLeague { get; set; }
    }
}
