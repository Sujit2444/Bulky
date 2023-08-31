using BulkyWeb.Db;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext applicationDbContext)
        {
                _dbContext= applicationDbContext;
        }
        public IActionResult Index()
        {
            List<Category> CategoryList = _dbContext.Categories.ToList();
            return View();
        }
    }
}
