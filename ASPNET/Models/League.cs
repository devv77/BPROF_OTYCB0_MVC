using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public enum RaceType
    { circuit, sprint}
    public class League
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [Range(0, 10)]
        public int Rating { get; set; }
        public bool Homology { get; set; }//open wheeled=1 or sport/touring=0
        public RaceType RaceTypes { get; set; }        
        
        public virtual ICollection<Team> Teams{get;set;}

        public override bool Equals(object obj)
        {
            if (obj is League)
            {
                League league= obj as League;
                return this.LID == league.LID && this.Name== league.Name && this.Rating == league.Rating
                    && this.Homology == league.Homology && this.RaceTypes == league.RaceTypes ;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

    }
}
