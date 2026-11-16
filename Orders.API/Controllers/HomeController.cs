using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Orders.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
      [HttpGet("/")]
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

      
    }
}
