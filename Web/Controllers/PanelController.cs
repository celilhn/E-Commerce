using Application.Filters;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    [AdminAuthorize(AdminUserTypes.Admin)]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
