using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Stat
    {
        public List<Driver> DriversOfOldestTeam { get; set; }
        public List<Driver> drivers { get; set; }
        public List<Team> TeamsOfBestLeague { get; set; }
    }
}
