using BigonEcommerce.Models;
using Infrastructure.Entities;
using BigonEcommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Globalization;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using BigonEcommerce.Data.DataAcces;

namespace BigonEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BigondbContext _context;
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger, BigondbContext context, IEmailService emailService)
        {
            _logger = logger;
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            string pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            bool isValid = Regex.IsMatch(email, pattern);

            if ( !isValid)
            {
                    return Json(new
                {
                    error=true,
                    message="Duzgun email daxil edin !"
                });
            }

            var subscriber = _context.Subscribers.FirstOrDefault(x=>x.EMailAdress==email);
            if (subscriber != null && !subscriber.IsApproved ) {
                return Ok(new
                {
                    success = true,
                    message = $"{email} unvanina tesdiq linki gonderildi. Zehmet olmasa tesdiq edin"
                });
            }
            if (subscriber != null && subscriber.IsApproved)
            {
                return Ok(new
                {
                    success = true,
                    message = $"{email} unvani tesdiq edilmisdir"
                });
            }

            var newSubscriber = new Subscriber()
            {
                CreatedAt= DateTime.Now,
                EMailAdress = email
            };

            _context.Subscribers.Add(newSubscriber);
            _context.SaveChanges();

            string token = $"#demo-{newSubscriber.EMailAdress}-{newSubscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-bigon";
            token = HttpUtility.UrlEncode(token);

            string url = $"{Request.Scheme}://{Request.Host}/subscribe-approve?token={token}";
            string body = $"Please click to link accept subscription <a href=\"{url}\">Click!</a>";

            await _emailService.SendMailAsync(email, "Subscription", body);

            return Ok(new
            {
                success = true,
                message = $"{email} unvanina tesdiq linki gonderildi. Zehmet olmasa tesdiq edin"
            });
        }

        [Route("/subscribe-approve")]
        public async Task<IActionResult> SubscribeApprove(string token)
        {
            string pattern = @"#demo-(?<email>[^-]*)-(?<date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})-bigon";
                
            Match match = Regex.Match(token, pattern);

            if (!match.Success)
            {
                return Content("token is broken!");
            }

            string email = match.Groups["email"].Value;
            string dateStr = match.Groups["date"].Value;

            if (!DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss.fff", null, DateTimeStyles.None, out DateTime date))
            {
                return Content("token is broken!");
            }

            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(m => m.EMailAdress.Equals(email) && m.CreatedAt == date);

            if (subscriber == null)
            {
                return Content("token is broken!");
            }

            if (!subscriber.IsApproved)
            {
                subscriber.IsApproved = true;
                subscriber.ApprovedAt = DateTime.Now;
            }
            await _context.SaveChangesAsync();


            return Content($"Success: Email: {email}\n" +
                $"Date: {date}");
        }



        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
