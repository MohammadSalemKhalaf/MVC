using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoriesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ViewResult Index()
        {
            var categories=context.Categories.ToList();
            //var categories = context.Categories.Select(c=>c.Name).ToList();
            return View("index",categories);
        }
        public ViewResult Details(int id)
        {
            Console.WriteLine($"Details method called with id: {id}");
            var category = context.Categories.Find(id);

            return View("Details", category);
        }

        [HttpGet]
        public ViewResult Create()
        {

            return View("Create", new Category());
        }

        [HttpPost]
        public IActionResult Create(Category request)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", request);
            }
            var flag = context.Categories.Any(c => c.Name == request.Name);
            if (flag)
            {
                ModelState.AddModelError("Name", "Category name already exists.");
                return View("Create", request);
            }
            context.Categories.Add(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
               var category=context.Categories.Find(id);
            if(category is null)
            {
                return View("Delete");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit() 
        {
            return View("Edit", new Category());
        }
        [HttpPost]
        public IActionResult Edit(Category request)
        {
           // var request = context.Categories.Find(id);
            var flag = context.Categories.Any(c => c.Name == request.Name && c.Id != request.Id);

            if (!ModelState.IsValid)
            {
                return View("Edit", request);

            }
            if (flag)
            {
                ModelState.AddModelError("Name", "Category name already exists.");
                return View("Edit", request);
            }
            context.Update(request);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
