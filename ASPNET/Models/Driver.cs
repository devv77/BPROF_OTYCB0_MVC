using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Driver
    {
        [Key]
        public string DID { get; set; }
        [StringLength(50)]
        public string DName { get; set; }
        public int BornYear { get; set; }
        [StringLength(25)]
        public string CountryB { get; set; }
        public int RaceNumber { get; set; }
        [NotMapped]
        public virtual Team OwnTeam { get; set; }
        public string TID { get; set; }
        public string TIDN { get; set; }
    }
}
