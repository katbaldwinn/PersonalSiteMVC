using Dynamic_Site.Models; //Grants access to ContactViewModel
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

          public IActionResult Contact(ContactViewModel cvm)
          {
               
               if (!ModelState.IsValid)
               {
                    

                    return View(cvm);
               }

               

               #region Email Setup Steps & Email Info

               //1. Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution
               //2. Go to the Browse tab and search for NETCore.MailKit
               //3. Click NETCore.MailKit
               //4. On the right, check the box next to the CORE1 project, then click "Install"
               //5. Once installed, return here
               //6. Add the following using statements & comments:
               //      - using MimeKit; //Added for access to MimeMessage class
               //      - using MailKit.Net.Smtp; //Added for access to SmtpClient class
               //7. Once added, return here to continue coding email functionality

               //MIME - Multipurpose Internet Mail Extensions - Allows email to contain
               //information other than ASCII, including audio, video, images, and HTML

               //SMTP - Simple Mail Transfer Protocol - An internet protocol (similar to HTTP)
               //that specializes in the collection & transfer of email data

               #endregion

               //format
               string message = $"You have received a new email from your site's contact form!<br />" +
                   $"Sender: {cvm.Name}<br/>Email: {cvm.Email}<br />Subject: {cvm.Subject}<br />Message: {cvm.Message}";

               // MimeMessage 
               var mm = new MimeMessage();

            

               // credentials for this email user 
               mm.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

               // our personal email address
               mm.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

               mm.Subject = cvm.Subject;

               //The body of the email will be formatted with the string we created above
               mm.Body = new TextPart("HTML") { Text = message };

               //"urgent" so it will be flagged in our email client
               mm.Priority = MessagePriority.Urgent;

               //user's email address to the list of ReplyTo addresses.
               mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

               // create the SmtpClient object used to send the email. 
               using (var client = new SmtpClient())
               {
                    //Connect to the mail server
                    client.Connect(_config.GetValue<string>("Credentials:Email:Client"), 8889);

                    //Log in to the mail server using the credentials for our email user.
                    client.Authenticate(

                        //Username
                        _config.GetValue<string>("Credentials:Email:User"),

                        //Password
                        _config.GetValue<string>("Credentials:Email:Password")

                        );

                    
                    try
                    {
                         client.Send(mm);
                    }
                    catch (Exception ex)
                    {
                         //If there's an issue, we can store an error message in a ViewBag variable 

                         ViewBag.ErrorMessage = $"There was an error processing your request. Please try again later.<br />" +
                             $"Error Message: {ex.StackTrace}";

                         return View(cvm);
                    }

               }
               return View("EmailConfirmation", cvm);
          }






     }
}