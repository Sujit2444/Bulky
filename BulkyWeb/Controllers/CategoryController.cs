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

    }
}
