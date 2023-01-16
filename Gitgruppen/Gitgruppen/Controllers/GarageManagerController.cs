using Gitgruppen.Data;
using Gitgruppen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gitgruppen.Controllers
{
    public class GarageManagerController : Controller
    {

        private readonly GitgruppenContext _context;

        public GarageManagerController(GitgruppenContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> OverView()
        {

            if (_context.Vehicle == null)
            {
                return NotFound();
            }

            var overViewModel = await _context.Vehicle.Select(e => new OverViewModel
            {

                Type = _context.VehicleType.Select(e => e.Type).First(),
                LicensePlate = e.LicensePlate,
                Brand = e.Brand,
                Arrived = e.Arrived,
                ParkedTime = e.Arrived - DateTime.Now

            }).ToListAsync();

            return View(overViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
