using BLL;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(option => {
		option.LoginPath = "/Auth/Index";
		option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
	});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "logout",
		pattern: "logout",
		defaults: new { controller = "Auth", action = "Logout" });

	// Your other routes...
});
