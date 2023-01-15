using Bogus;
using Bogus.Extensions.Sweden;
using Gitgruppen.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gitgruppen.Controllers
{
    public class SettingsController : Controller
    {
        private readonly GitgruppenContext _context;

        public SettingsController(GitgruppenContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Seed(string AddMembers, string AddParkingSpots, string AddVehicles, string AddGarage, string DropDatabase)
        {
            int nrOfMembers;
            if(AddMembers != null) if (int.TryParse(AddMembers, out nrOfMembers)){
                    await SeedData.SeedData.AddMembers(_context, nrOfMembers);
                    ViewData["Result"] = $"Added {nrOfMembers} members";
                }

            int nrOfParkingSpots;
            if (AddParkingSpots != null) if (int.TryParse(AddParkingSpots, out nrOfParkingSpots))
                {
                    await SeedData.SeedData.AddParkingSpots(_context, nrOfParkingSpots);
                    ViewData["Result"] = $"Added {nrOfParkingSpots} parking spots";
                }

            int nrOfVehicles;
            if (AddVehicles != null) if (int.TryParse(AddVehicles, out nrOfVehicles))
                {
                    await SeedData.SeedData.AddVehicles(_context, nrOfVehicles);
                    ViewData["Result"] = $"Added {nrOfVehicles} vehicles";
                }

            if (AddGarage != null) if (AddGarage.Equals("true"))
                {
                    await SeedData.SeedData.AddGarage(_context);
                    ViewData["Result"] = $"Added a new garage";
                }

            if (AddVehicles != null) if (DropDatabase.Equals("true"))
                {
                    await SeedData.SeedData.DropDatabase(_context);
                    ViewData["Result"] = $"Database was dropped";
                }
            return View();
        }


        public async Task<IActionResult> ParkingSpots()
        {
            return _context.ParkingSpot != null ?
            View(await _context.ParkingSpot.ToListAsync()) :
            Problem("Entity set 'GitgruppenContext.ParkingSpot'  is null.");

        }
    }
}
