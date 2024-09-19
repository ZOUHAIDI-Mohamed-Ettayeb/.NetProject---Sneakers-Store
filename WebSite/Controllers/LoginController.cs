using Microsoft.AspNetCore.Mvc;
using Models.Auth;

namespace WebSite.Controllers
{
    public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(UserAuthModel model)
		{
			return View();
		}
	}
}
