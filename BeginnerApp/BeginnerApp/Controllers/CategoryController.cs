using BeginnerApp.Data;
using BeginnerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeginnerApp.Controllers
{
    public class CategoryController : Controller
    {
        //creating ApplicationDbContext object for db access
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _dbContext.Categories;
            return View(objCategoryList);
        }

        //GET | Go to the create view
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category) 
        {
            // Server side validation
            if (ModelState.IsValid) 
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(category);


        }
    }
}
