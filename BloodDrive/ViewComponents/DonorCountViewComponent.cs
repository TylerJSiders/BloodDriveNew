using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BloodDrive.Models.Database;

namespace BloodDrive.ViewComponents
{
    public class DonorCountViewComponent : ViewComponent
    {
        private readonly IDBRepository repo;

        public DonorCountViewComponent(IDBRepository repo)
        {
            this.repo = repo;
        }

        public IViewComponentResult Invoke()
        {
            int numberOfDonors = repo.DonorCount();
            return View(numberOfDonors);
        }

    }
}
