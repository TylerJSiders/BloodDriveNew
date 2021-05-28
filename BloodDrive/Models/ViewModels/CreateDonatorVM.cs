using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDrive.Models.Database;

namespace BloodDrive.Models.ViewModels
{
    public class CreateDonatorVM
    {
        public Donator donator { get; set; }
        public List<BloodType> bloodTypes { get; set; }
        public CreateDonatorVM()
        {
            donator = new();
        }
        public CreateDonatorVM(IDBRepository repo)
        {
            bloodTypes = repo.GetListOfBloodTypes();
            donator = new Donator();
        }
    }
}
