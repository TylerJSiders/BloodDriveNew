using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodDrive.Models
{
    public class Record
    {
        public int ID { get; set; }
        public DateTime DateDonated { get; set; }

        //Navigation Properties
        public int DonatorID { get; set; }
        public Donator donator { get; set; }
    }
}
