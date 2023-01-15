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

        public async Task<IActionResult> Seed(string AddMembers)
        {
            int nrOfMembers;
            if(AddMembers != null) if (int.TryParse(AddMembers, out nrOfMembers)){
                    await SeedData.SeedData.AddMembers(_context, nrOfMembers);
                    ViewData["Result"] = $"Added ${nrOfMembers} members";
                    return RedirectToAction(nameof(Index));

                }

            return View();
        }


        public IActionResult ParkingSpots()
        {
            return View();
        }
    }
}
