using BeginnerApp.Data;
using BeginnerApp.Interfaces;
using BeginnerApp.Models;
using BeginnerApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Controllers
{
    public class AuctionController : Controller
    {
        //creating ApplicationDbContext object for db access
        private readonly ApplicationDbContext _dbContext;
        private readonly IAuctionRepository _auctionRepository;

        public AuctionController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _auctionRepository = new AuctionRepository();
        }

        public IActionResult Index()
        {
            IEnumerable<Auction> objAuctionList = _auctionRepository.GetAuctions();
            return View(objAuctionList);
        }

        //GET | Go to the create view
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Auction Auction)
        {
            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Auctions.Add(Auction);
                _dbContext.SaveChanges();

                TempData["success"] = "Record created successfully";

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(Auction);
        }

        //UPDATE
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var AuctionFromDb = _dbContext.Auctions.Find(id);
            //var firstValue = _dbContext.Auctions.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Auctions.SingleOrDefault(u => u.Id == id);

            if (AuctionFromDb == null)
            {
                return NotFound();
            }

            return View(AuctionFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Auction Auction)
        {

            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Auctions.Update(Auction);
                _dbContext.SaveChanges();

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(Auction);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var AuctionFromDb = _dbContext.Auctions.Find(id);
            //var firstValue = _dbContext.Auctions.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Auctions.SingleOrDefault(u => u.Id == id);

            if (AuctionFromDb == null)
            {
                return NotFound();
            }

            return View(AuctionFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dbContext.Auctions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }



            _dbContext.Auctions.Remove(obj);
            _dbContext.SaveChanges();

            //Redirects to the action in the same controller
            return RedirectToAction("Index");
        }
    }
}
