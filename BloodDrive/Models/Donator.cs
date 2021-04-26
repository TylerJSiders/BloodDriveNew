using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDrive.Models
{
    public class Donator
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public string State { get; set; }
        public bool Elligible { get; set; }
        
        //Navigation Properties
        [Required]
        public int BloodTypeID { get; set; }
        public virtual BloodType BloodType { get; set; }
        

    }
}
