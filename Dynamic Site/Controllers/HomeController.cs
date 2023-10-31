using Dynamic_Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.Extensions.Configuration;//grants easy access to info in appsettings.json
using MimeKit;
using MailKit.Net.Smtp;

namespace Dynamic_Site.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _config;

		public HomeController(ILogger<HomeController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public IActionResult Resume()
		{
			return View();
		}

		public IActionResult Portfolio()
		{
			return View();
		}

		public IActionResult Links()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Contact()
		{
			return View();
		}







	}
}