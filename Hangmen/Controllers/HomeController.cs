using Microsoft.AspNetCore.Mvc;
using Hangmen.Models;
namespace Hangmen.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}
