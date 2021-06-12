using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Models
{
    public enum ESuppliers
    { Ferrari, Honda, Mercedes, Renault, Audi, BMW, Gibson, Seat}
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TID { get; set; }
        [StringLength(150)]
        public string TName { get; set; }
        public int Created { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        
        public ESuppliers Engine { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public string LID { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual League League { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Team)
            {
                Team team = obj as Team;
                return this.LID == team.LID && this.TName == team.TName && this.Created == team.Created
                    && this.Country == team.Country && this.Engine == team.Engine && this.Drivers== team.Drivers
                    && this.TID == team.TID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }

    }
}
