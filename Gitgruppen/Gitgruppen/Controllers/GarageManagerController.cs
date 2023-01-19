using AutoMapper;
using Gitgruppen.Data;
using Gitgruppen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gitgruppen.Controllers
{
    public class GarageManagerController : Controller
    {

        private readonly GitgruppenContext _context;
        private readonly IMapper mapper;

        public GarageManagerController(GitgruppenContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IActionResult> OverView()
        {
            if (_context.Vehicle == null)
            {
                return NotFound();
            }

            var autoMapperViewModel = await mapper.ProjectTo<OverViewModel>(_context.Vehicle)
                .OrderBy(m => m.LicensePlate)
                .ToListAsync();
         
            return View(autoMapperViewModel);
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Search(string sort, string licensePlate)
        {
            ViewData["TypeSort"] = String.IsNullOrEmpty(sort) ? "typeDesc" : "";
            ViewData["LicenseSort"] = sort == "arrived" ? "arrDesc" : "arrived";
            ViewData["LicensePlate"] = licensePlate;

         
            var vehicles = from v in _context.Vehicle select v;

            if (!String.IsNullOrEmpty(licensePlate))
            {
                vehicles = vehicles.Where(v => v.LicensePlate.Contains(licensePlate));
            }

            switch (sort)
            {
                case "typeDesc":
                    vehicles = vehicles.OrderByDescending(v => v.MemberPersNr);
                    break;

                case "arrived":
                    vehicles = vehicles.OrderBy(v => v.LicensePlate);
                    break;

                case "arrDesc":
                    vehicles = vehicles.OrderByDescending(v => v.LicensePlate);
                    break;

                default:
                    vehicles = vehicles.OrderBy(v => v.MemberPersNr);
                    break;
            }

            var autoMapperViewModel = await mapper.ProjectTo<OverViewModel>(vehicles.AsNoTracking())
                
                 .ToListAsync();

            return View("Search", autoMapperViewModel);

        }
    }
}
