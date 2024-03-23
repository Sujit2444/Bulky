using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext dBContext)
        {
                _dbContext = dBContext;
        }
        public IActionResult Index()
        {
            List<Category>categoryList= _dbContext.Categories.ToList();
            return View(categoryList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (category.Name==category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Dispaly Order can not exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
