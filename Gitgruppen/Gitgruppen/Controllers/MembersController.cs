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
using Bogus.DataSets;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System.Globalization;

namespace Gitgruppen.Controllers
{
    public class MembersController : Controller
    {
        private readonly GitgruppenContext _context;
        private readonly IMapper mapper;

        public MembersController(GitgruppenContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
  
            var autoMapperViewModel = await mapper.ProjectTo<MemberView>(_context.Member)
                .OrderBy(m => m.FirstName)
                .ToListAsync(); 
                    

            return View(autoMapperViewModel);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.PersNr == id);
            if (member == null)
            {
                return NotFound();
            }

            MemberDetailsView mdv = new MemberDetailsView
            {
                PersNr = member.PersNr,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Vehicles = _context.Vehicle.Where(e => e.Member.PersNr == member.PersNr).Select(e => new VehicleView
                {
                      LicensePlate = e.LicensePlate,
                      Arrived = e.Arrived,
                      Color = e.Color,
                      Brand = e.Brand,
                      Model = e.Model,
                      NumberOfWheels = e.NumberOfWheels,
                      VehicleTypeId = e.VehicleTypeId,
                      VehicleTypeName = e.VehicleType.Type,
                      VehicleType = e.VehicleType,
                      Member = e.Member,
                      ParkingSpotId = e.ParkingSpotId
            }).ToList()
            };

            return View(mdv);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersNr,FirstName,LastName")] MemberView member)
        {
            //if (ModelState.IsValid)
            //{
            //var cultureInfo = new CultureInfo("se-SE");
            //DateTime d = DateTime.Parse(member.PersNr, cultureInfo);
            //int age = DateTime.Now.Year - d.Year;

            //if(age >= 18) {

            _context.Add(new Member
                   {
                       PersNr = member.PersNr,
                       FirstName= member.FirstName,
                       LastName= member.LastName
                   });
                   await _context.SaveChangesAsync();
                //}
                return RedirectToAction(nameof(Index));
            //}
             //return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersNr,FirstName,LastName")] Member member)
        {
            if (id != member.PersNr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.PersNr))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.PersNr == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Member == null)
            {
                return Problem("Entity set 'GitgruppenContext.Member'  is null.");
            }
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(string id)
        {
          return (_context.Member?.Any(e => e.PersNr == id)).GetValueOrDefault();
        }
    }
}
