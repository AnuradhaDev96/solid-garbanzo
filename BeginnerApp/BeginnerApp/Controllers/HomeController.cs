using BeginnerApp.Data;
using BeginnerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Controllers
{
    // Home controller
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signin(string username, string password)
        {
            if (username == "" || password == "")
            {
                return NotFound();
            }

            var userFromDb = _dbContext.Players.SingleOrDefault(u => u.Username == username  && u.Password == password);
            //var firstValue = _dbContext.Auctions.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Auctions.SingleOrDefault(u => u.Id == id);

            if (userFromDb == null)
            {
                TempData["error"] = "Invalid User";
                return RedirectToAction("SignIn");
            }
            else {
                TempData["success"] = "Signed In successfully";
                return RedirectToAction("Logged");
            }

            //return View(userFromDb);
        }

        public IActionResult Logged()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}                   
