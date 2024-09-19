using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSite.Controllers
{
	public class SneakerController : Controller
	{
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}
	}
}
