using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public enum ESuppliers
    { Ferrari, Honda, Mercedes, Renault, Audi, BMW, Gibson, Seat}
    public class Team
    {
        [Key]
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
        public virtual League League { get; set; }
        


    }
}
