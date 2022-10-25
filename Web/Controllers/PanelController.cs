using Application.Filters;
using Microsoft.AspNetCore.Mvc;
using static Domain.Constants.Constants;

namespace Web.Controllers
{
    [Authorize(UserTypes.Admin)]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
