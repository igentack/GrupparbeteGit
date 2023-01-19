using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GitGruppen.Core;
using Gitgruppen.Data;
using Gitgruppen.Models;

namespace Gitgruppen.Controllers
{
    public class ParkingSpotsController : Controller
    {
        private readonly GitgruppenContext _context;

        public ParkingSpotsController(GitgruppenContext context)
        {
            _context = context;
        }

        // GET: ParkingSpots
        public async Task<IActionResult> Index()
        {
              return _context.ParkingSpot != null ? 
                          View(await _context.ParkingSpot.ToListAsync()) :
                          Problem("Entity set 'GitgruppenContext.ParkingSpot'  is null.");
        }


        public async Task<IActionResult> Checkin(string id)
        {
            Vehicle vehicle = _context.Vehicle.Where(e => e.LicensePlate == id).First();
            Member member = _context.Member.Where(e => e.PersNr == vehicle.MemberPersNr).First();
            vehicle.Arrived = DateTime.Now;
            _context.Update(vehicle);
            await _context.SaveChangesAsync();


            return View(new CheckinView
            {
                MemberPersNr = member.PersNr,
                licenseplate = id,
                FreeParkingSpots = _context.ParkingSpot.ToList(),
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkin(CheckinView checkinView)
        {
            var vehicle = await _context.Vehicle.FindAsync(checkinView.licenseplate);
            vehicle.ParkingSpotId = checkinView.Id;
            _context.Update(vehicle);
            await _context.SaveChangesAsync();

            var routeValues = new RouteValueDictionary {
                  { "id", vehicle.MemberPersNr }
            };

            return RedirectToAction("Details", "Members", routeValues);
        }



        // GET: ParkingSpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingSpot == null)
            {
                return NotFound();
            }

            var parkingSpot = await _context.ParkingSpot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            return View(parkingSpot);
        }

        // GET: ParkingSpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SpotName")] ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingSpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingSpot == null)
            {
                return NotFound();
            }

            var parkingSpot = await _context.ParkingSpot.FindAsync(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }
            return View(parkingSpot);
        }

        // POST: ParkingSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SpotName")] ParkingSpot parkingSpot)
        {
            if (id != parkingSpot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingSpot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSpotExists(parkingSpot.Id))
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
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingSpot == null)
            {
                return NotFound();
            }

            var parkingSpot = await _context.ParkingSpot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            return View(parkingSpot);
        }

        // POST: ParkingSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingSpot == null)
            {
                return Problem("Entity set 'GitgruppenContext.ParkingSpot'  is null.");
            }
            var parkingSpot = await _context.ParkingSpot.FindAsync(id);
            if (parkingSpot != null)
            {
                _context.ParkingSpot.Remove(parkingSpot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpotExists(int id)
        {
          return (_context.ParkingSpot?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
