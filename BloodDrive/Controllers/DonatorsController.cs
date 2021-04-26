using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodDrive.Models;
using BloodDrive.Models.Database;
using BloodDrive.Models.ViewModels;

namespace BloodDrive.Controllers
{
    public class DonatorsController : Controller
    {
        private readonly IDBRepository _context;

        public DonatorsController(IDBRepository context)
        {
            _context = context;
        }

        // GET: Donators
        public async Task<IActionResult> Index()
        {
            //var c = _context.
            //var dBContext = _context.Donators.Include(d => d.BloodType);
            return View(await _context.GetDonators());
        }

        // GET: Donators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donator = await _context.GetDonator(id);
            if (donator == null)
            {
                return NotFound();
            }

            return View(donator);
        }

        // GET: Donators/Create
        public IActionResult Create()
        {
            CreateDonatorVM VM = new CreateDonatorVM(_context);
            return View(VM);
        }

        // POST: Donators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateDonatorVM donatorVM)
        //[Bind("ID,FirstName,LastName,Sex,Email,PhoneNumber,State,Elligible,BloodTypeID")] 
        {
            donatorVM.donator.BloodType = _context.GetBloodType(donatorVM.donator.BloodTypeID);
            if (ModelState.IsValid)
            {
                await _context.AddDonator(donatorVM.donator);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["BloodTypeID"] = new SelectList(_context.BloodTypes, "ID", "ID", donator.BloodTypeID);
            return View(donatorVM);
        }

        // GET: Donators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donator = await _context.GetDonator(id);
            if (donator == null)
            {
                return NotFound();
            }
            
            ViewData["BloodTypeID"] = new SelectList(_context.GetListOfBloodTypes(), "ID", "Type", donator.BloodTypeID);
            return View(donator);
        }

        //// POST: Donators/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Sex,Email,PhoneNumber,State,Elligible,BloodTypeID")] Donator donator)
        {
            if (id != donator.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.UpdateDonator(donator);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.DonatorExists(donator.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloodTypeID"] = new SelectList(_context.GetListOfBloodTypes(), "ID", "Type", donator.BloodTypeID);
            return View(donator);
        }

        // GET: Donators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (!_context.DonatorExists(id))
                return NotFound();

            return View(await _context.GetDonator(id));
        }

        // POST: Donators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!_context.DonatorExists(id))
                return NotFound();
            await _context.DeleteDonator(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
