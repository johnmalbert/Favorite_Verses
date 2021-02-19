using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuotingDojo.Models;
using Microsoft.EntityFrameworkCore;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Quotes")]
        public IActionResult Quotes()
        {
            ViewBag.Verses = _context.Quotes.OrderByDescending(u => u.CreatedAt);
            return View();
        }

        [HttpPost("post-quote")]
        public IActionResult PostQuote(Quote newQuote)
        {
            if(ModelState.IsValid)
            {
                //add to db
                _context.Add(newQuote);
                _context.SaveChanges();
                return RedirectToAction("Quotes");
            }
            else
            {
                return View("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
