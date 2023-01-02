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

                case "color":
                    vehicles = vehicles.OrderBy(v => v.Color);
                    break;

                case "brand":
                    vehicles = vehicles.OrderBy(v => v.Brand);
                    break;

                case "model":
                    vehicles = vehicles.OrderBy(v => v.Model);
                    break;

                case "numberofwheels":
                    vehicles = vehicles.OrderBy(v => v.NumberOfWheels);
                    break;

                case "licenseplate":
                    vehicles = vehicles.OrderBy(v => v.LicensePlate);
                    break;

                default:
                    vehicles = vehicles.OrderBy(v => v.Type);
                    break;
            }


            var overViewModel = await vehicles.AsNoTracking().Select(e => new OverViewModel
            {

                Type = e.Type,
                LicensePlate = e.LicensePlate,
                Brand = e.Brand,
                Arrived = e.Arrived,
                Model= e.Model,
                Color= e.Color,
                NumberOfWheels= e.NumberOfWheels,
                ParkedTime = e.Arrived - DateTime.Now

            }).ToListAsync();

            return View(overViewModel); 
                       
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
        
        // GET: ParkedVehicles/DetailsModal
        public async Task<IActionResult> DetailsModal()
        {
            var id = "ABC222";
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

            return PartialView("DetailsModal", parkedVehicle);
        }
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
            string opResult;
            if (ParkedVehicleExists(parkedVehicle.LicensePlate) != true)
            {

            if (ModelState.IsValid)
            {
                    parkedVehicle.Arrived = DateTime.Now;
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();

                var overViewModel = new OverViewModel()
                {
                    Type = parkedVehicle.Type,
                    LicensePlate = parkedVehicle.LicensePlate,
                    Brand = parkedVehicle.Brand,
                    Arrived = parkedVehicle.Arrived,
                    Model = parkedVehicle.Model,
                    Color = parkedVehicle.Color,
                    NumberOfWheels = parkedVehicle.NumberOfWheels,
                    ParkedTime = parkedVehicle.Arrived - DateTime.Now

                };
                ViewData["opResult"] = "success";
                return View(nameof(ResultView), overViewModel);
            }
            ViewData["opResult"] = "error";
            return View(nameof(ResultView), null);

            }else
            {
                ViewData["opResult"] = "exists";
                return View(nameof(ResultView), null);
            }
        }


        public IActionResult ResultView(OverViewModel model)
        {
            return View(nameof(ResultView), model);
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

                var overViewModel = new OverViewModel()
                {
                    Type = parkedVehicle.Type,
                    LicensePlate = parkedVehicle.LicensePlate,
                    Brand = parkedVehicle.Brand,
                    Arrived = parkedVehicle.Arrived,
                    Model = parkedVehicle.Model,
                    Color = parkedVehicle.Color,
                    NumberOfWheels = parkedVehicle.NumberOfWheels,
                    ParkedTime = parkedVehicle.Arrived - DateTime.Now

                };


                ViewData["opResult"] = "success";
                return View(nameof(ResultView), overViewModel);
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


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Receipt(string id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            double PricePerHour = 3;
            var parkedVehicle = await _context.ParkedVehicle.Select(e => new ReceiptModel
            {
                Type = e.Type,
                LicensePlate = e.LicensePlate,
                Arrived = e.Arrived,
                Departured = DateTime.Now,
                HoursParked = Math.Round((DateTime.Now - e.Arrived).TotalHours, 2),
                ParkedTime = DateTime.Now - e.Arrived,
            })
                .FirstOrDefaultAsync(m => m.LicensePlate == id);

            parkedVehicle.ParkingCost = Math.Round(3 + (parkedVehicle.HoursParked * PricePerHour), 2);

            double days = Math.Round(parkedVehicle.ParkedTime.TotalDays);
            double hours = Math.Round(parkedVehicle.ParkedTime.TotalHours) - (days * 24);
            double minutes = Math.Round(parkedVehicle.ParkedTime.TotalMinutes) - ((hours + (days * 24)) * 60);
            if (minutes<0)
            {
                hours = hours - 1;
                minutes = minutes + 60;
            }
            if(hours<0)
            {
                days= days - 1;
                hours = hours + 24;
            }
            parkedVehicle.StrParkedTime = days.ToString() + " Days " + hours.ToString() + " Hours " + minutes.ToString() + " Minutes ";
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }
    }
}
