using Bogus;
using Bogus.Extensions.Sweden;
using Gitgruppen.Data;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Seed(string AddMembers, string AddParkingSpots, string AddVehicles)
        {
            int nrOfMembers;
            if(AddMembers != null) if (int.TryParse(AddMembers, out nrOfMembers)){
                    await SeedData.SeedData.AddMembers(_context, nrOfMembers);
                    ViewData["Result"] = $"Added ${nrOfMembers} members";
                }

            int nrOfParkingSpots;
            if (AddParkingSpots != null) if (int.TryParse(AddParkingSpots, out nrOfParkingSpots))
                {
                    await SeedData.SeedData.AddParkingSpots(_context, nrOfParkingSpots);
                    ViewData["Result"] = $"Added ${nrOfParkingSpots} parking spots";
                }

            int nrOfVehicles;
            if (AddVehicles != null) if (int.TryParse(AddVehicles, out nrOfVehicles))
                {
                    await SeedData.SeedData.AddVehicles(_context, nrOfVehicles);
                    ViewData["Result"] = $"Added ${nrOfVehicles} vehicles";
                }
            return View();
        }


        public IActionResult ParkingSpots()
        {
            return View();
        }
    }
}
