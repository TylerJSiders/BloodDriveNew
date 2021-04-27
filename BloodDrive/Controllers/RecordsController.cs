using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodDrive.Models.Database;
using BloodDrive.Models.ViewModels;
using BloodDrive.Models;

namespace BloodDrive.Controllers
{
    public class RecordsController : Controller
    {

        private readonly IDBRepository _context;

        public RecordsController(IDBRepository context)
        {
            _context = context;
        }


        // GET: RecordsController/Create
        public ActionResult Create(int? DonatorID)
        {
            if (!_context.DonatorExists(DonatorID))
                return NotFound();
            Record vm = new Record();
            ViewBag.Donator = _context.GetDonatorNAsync(DonatorID);
            return View(vm);
        }

        // POST: RecordsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Record record)
        {

            record.donator = _context.GetDonatorNAsync(record.DonatorID);
            var x = _context.AddRecord(record);
            return RedirectToAction("Index", "Donators");
        }

        // GET: RecordsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecordsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecordsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecordsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
