using Microsoft.AspNetCore.Mvc;

namespace Tomasos.Controllers
{
    public class AjaxController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetStrut()
        {
            return PartialView("_strutpartial");
        }
    }
}