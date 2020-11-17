using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public enum RaceType
    { circuit, sprint}
    public class League
    {
        [Key]
        public string LID { get; set; }
        [StringLength(25)]
        public string Name { get; set; }
        [Range(0, 10)]
        public int Rating { get; set; }
        public bool Homology { get; set; }
        public RaceType RaceTypes { get; set; }

        public virtual ICollection<Team> Teams{get;set;}

    }
}
