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
            //FOLLOWING VALIDATION CAN BE DONE IN CLIENT SIDE ALSO WITH PARTIAL VIEW. REFER THE VIEW FILE.

            //Add custom validation to be shown in the validation summary section
            if (category.Name == category.DisplayOrder.ToString())
            {
                //Display in summary error
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match Name");

                //Display in field error and summary error
                //ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match Name");
            }

            // Server side validation
            if (ModelState.IsValid) 
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                TempData["success"] = "Record created successfully";

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(category);
        }        

        //UPDATE
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _dbContext.Categories.Find(id);
            //var firstValue = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            //FOLLOWING VALIDATION CAN BE DONE IN CLIENT SIDE ALSO WITH PARTIAL VIEW. REFER THE VIEW FILE.

            //Add custom validation to be shown in the validation summary section
            if (category.Name == category.DisplayOrder.ToString())
            {
                //Display in summary error
                ModelState.AddModelError("CustomError", "The DisplayOrder cannot exactly match Name");

                //Display in field error and summary error
                //ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match Name");
            }

            // Server side validation
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();

                //Redirects to the action in the same controller
                return RedirectToAction("Index");

                //If you want to redirect to an action in another controller do like this
                //return RedirectToAction("Index", "OtherControllerName");
            }

            return View(category);
        }

        //DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFromDb = _dbContext.Categories.Find(id);
            //var firstValue = _dbContext.Categories.FirstOrDefault(u => u.Id == id);
            //var singleValue = _dbContext.Categories.SingleOrDefault(u => u.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _dbContext.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


           
            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();

            //Redirects to the action in the same controller
            return RedirectToAction("Index");
        }
    }
}
