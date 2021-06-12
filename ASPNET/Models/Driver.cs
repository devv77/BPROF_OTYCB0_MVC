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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public override bool Equals(object obj)
        {
            if (obj is Driver)
            {
                Driver driver = obj as Driver;
                return this.DID == driver.DID && this.DName == driver.DName && this.BornYear == driver.BornYear
                    && this.CountryB == driver.CountryB && this.RaceNumber == driver.RaceNumber && this.OwnTeam == driver.OwnTeam
                    && this.TID == driver.TID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }



    }
}
