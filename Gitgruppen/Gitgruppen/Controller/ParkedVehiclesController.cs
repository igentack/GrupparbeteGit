using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gitgruppen.Data;
using System.Diagnostics.CodeAnalysis;

namespace Gitgruppen.Models
{
    public class ParkedVehiclesController : Controller
    {
        private readonly GitgruppenContext _context;

        public ParkedVehiclesController(GitgruppenContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OverView()
        {

            if (_context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var overViewModel = await _context.ParkedVehicle.Select(e => new OverViewModel
            {

                Type = e.Type,
                LicensePlate = e.LicensePlate,
                Brand = e.Brand,
                Arrived= e.Arrived,
                ParkedTime = e.Arrived - DateTime.Now

            }).ToListAsync();
 
            return View(overViewModel);
        }

        // GET: ParkedVehicles, Searching Licenseplate and Sorting Columns
        public async Task<IActionResult> Index(string sort, string licensePlate)
        {
            ViewData["TypeSort"] = String.IsNullOrEmpty(sort) ? "typeDesc" : "";
            ViewData["ArrSort"] = sort == "arrived" ? "arrDesc" : "arrived";
            ViewData["LicensePlate"] = licensePlate;
           
            var vehicles = from v in _context.ParkedVehicle select v;

            if (!String.IsNullOrEmpty(licensePlate))
            {
                vehicles = vehicles.Where(v => v.LicensePlate.Contains(licensePlate));
            }

            switch (sort)
            {
                case "typeDesc":
                  vehicles = vehicles.OrderByDescending(v => v.Type);
                    break;

                case "arrived":
                    vehicles = vehicles.OrderBy(v => v.Arrived);
                    break;

                case "arrDesc":
                    vehicles = vehicles.OrderByDescending(v => v.Arrived);
                    break;

                default:
                    vehicles = vehicles.OrderBy(v => v.Type);
                    break;
            }

            return View(await vehicles.AsNoTracking().ToListAsync()); 
                       
        }
        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.LicensePlate == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicensePlate,Type,Arrived,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        private bool ParkedVehicleExists(string id)
        {
          return (_context.ParkedVehicle?.Any(e => e.LicensePlate == id)).GetValueOrDefault();
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LicensePlate,Type,Arrived,Color,Brand,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.LicensePlate)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.LicensePlate))
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
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.LicensePlate == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'GitgruppenContext.ParkedVehicle'  is null.");
            }
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);

            OverViewModel res = new OverViewModel();
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);

                res.Arrived = parkedVehicle.Arrived;
                res.LicensePlate = parkedVehicle.LicensePlate;
                res.Brand = parkedVehicle.Brand;

            } else res = null;
            
            await _context.SaveChangesAsync();


            return View("ResultView", res);
        }

        public IActionResult ResultView(OverViewModel model)
        {
            return View(nameof(ResultView), model);
        }

    }
}
