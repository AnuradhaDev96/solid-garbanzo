using BeginnerApp.Data;
using BeginnerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Controllers
{
    public class TrophyController : Controller
    {
        //creating ApplicationDbContext object for db access
        private readonly ApplicationDbContext _dbContext;

        public TrophyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Trophy> objTrophyList = _dbContext.Trophies;
            return View(objTrophyList);
        }

        //GET | Go to the create view
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Trophy Trophy)
        {
            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Trophies.Add(Trophy);
                _dbContext.SaveChanges();

                TempData["success"] = "Record created successfully";

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(Trophy);
        }

        //UPDATE
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var TrophyFromDb = _dbContext.Trophies.Find(id);
            //var firstValue = _dbContext.Trophies.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Trophies.SingleOrDefault(u => u.Id == id);

            if (TrophyFromDb == null)
            {
                return NotFound();
            }

            return View(TrophyFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Trophy Trophy)
        {

            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Trophies.Update(Trophy);
                _dbContext.SaveChanges();

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(Trophy);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var TrophyFromDb = _dbContext.Trophies.Find(id);
            //var firstValue = _dbContext.Trophies.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Trophies.SingleOrDefault(u => u.Id == id);

            if (TrophyFromDb == null)
            {
                return NotFound();
            }

            return View(TrophyFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dbContext.Trophies.Find(id);
            if (obj == null)
            {
                return NotFound();
            }



            _dbContext.Trophies.Remove(obj);
            _dbContext.SaveChanges();

            //Redirects to the action in the same controller
            return RedirectToAction("Index");
        }
    }
}
