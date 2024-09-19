using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models.Auth;
using System.Security.Claims;
using BLL;
using Microsoft.AspNetCore.Http;

namespace Admin.Controllers
{
    public class AuthController : Controller
    {

		public IActionResult Index()
		{
			ClaimsPrincipal claimUser = HttpContext.User;

			if (claimUser.Identity.IsAuthenticated)
				return RedirectToAction("Dashboard", "Sneaker");
			return View();
		}

		[HttpPost]
		public IActionResult Index(UserAuthModel model)
		{
			UserService utilisateurService = new UserService();
			var us = utilisateurService.VerifierCompte(model);

			if (us != null)
			{
				List<Claim> claims = new List<Claim>() {
					new Claim(ClaimTypes.Email, us.AdresseMail),
					new Claim("Societe","EMSI"),
					new Claim(ClaimTypes.Name, us.Nom),
					new Claim(ClaimTypes.NameIdentifier, us.Id.ToString()),
				};

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
					CookieAuthenticationDefaults.AuthenticationScheme);

				AuthenticationProperties properties = new AuthenticationProperties()
				{

					AllowRefresh = true,
					//IsPersistent = us.KeepLoggedIn
				};

				HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
					new ClaimsPrincipal(claimsIdentity), properties);

				return RedirectToAction("Dashboard", "Sneaker");
			}



			ViewData["ValidateMessage"] = "User Not Found";
			return View();
		}

		public IActionResult Logout()
		{
			// Sign out the user
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			// Redirect to the login page or any other page after logout
			return RedirectToAction("Index", "Home"); // Change "Login" to the appropriate controller and action for your login page
		}
	}
}
