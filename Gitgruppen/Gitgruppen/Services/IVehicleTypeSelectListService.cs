using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gitgruppen.Services
{
    public interface IVehicleTypeSelectListService
    {
        Task<IEnumerable<SelectListItem>> GetVehicleTypesAsync();
    }
}