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
    }
}
