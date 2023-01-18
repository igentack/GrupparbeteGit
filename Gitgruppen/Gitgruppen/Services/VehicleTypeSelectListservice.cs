using Gitgruppen.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Gitgruppen.Services
{
    public class VehicleTypeSelectListservice : IVehicleTypeSelectListService
    {
        private readonly GitgruppenContext gitgruppenContext;
        
        public VehicleTypeSelectListservice(GitgruppenContext gitgruppenContext)
        {
            this.gitgruppenContext = gitgruppenContext;
        }

        public async Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync()
        {
            return await gitgruppenContext.VehicleType.Select(p => p.Type).Distinct().Select(c => new SelectListItem
            {
                Text = c.ToString(),
                Value = c.ToString()
            
            }).ToListAsync();

        }
    }
}
