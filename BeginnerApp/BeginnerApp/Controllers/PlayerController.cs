using BeginnerApp.Data;
using BeginnerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Controllers
{
    public class PlayerController : Controller
    {
        //creating ApplicationDbContext object for db access
        private readonly ApplicationDbContext _dbContext;

        public PlayerController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Player> objPlayerList = _dbContext.Players;
            return View(objPlayerList);
        }

        //GET | Go to the create view
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Player Player)
        {
            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Players.Add(Player);
                _dbContext.SaveChanges();

                TempData["success"] = "Record created successfully";

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(Player);
        }

        //UPDATE
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var PlayerFromDb = _dbContext.Players.Find(id);
            //var firstValue = _dbContext.Players.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Players.SingleOrDefault(u => u.Id == id);

            if (PlayerFromDb == null)
            {
                return NotFound();
            }

            return View(PlayerFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Player Player)
        {

            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Players.Update(Player);
                _dbContext.SaveChanges();

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(Player);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var PlayerFromDb = _dbContext.Players.Find(id);
            //var firstValue = _dbContext.Players.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Players.SingleOrDefault(u => u.Id == id);

            if (PlayerFromDb == null)
            {
                return NotFound();
            }

            return View(PlayerFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dbContext.Players.Find(id);
            if (obj == null)
            {
                return NotFound();
            }



            _dbContext.Players.Remove(obj);
            _dbContext.SaveChanges();

            //Redirects to the action in the same controller
            return RedirectToAction("Index");
        }
    }
}
