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
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Dispaly Order can not exactly match the name");
            }

            //if (category.Name!= null && category.Name.ToLower()=="test")
            //{
            //    ModelState.AddModelError("", "Test is invalid for Category Name");
            //}


            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int? categoryId)
        {
            if (categoryId == null || categoryId==0)
            {
                return NotFound();
            }
            Category? dbCategory = _dbContext.Categories.Find(categoryId);
            //Category? dbCategory2 = _dbContext.Categories.FirstOrDefault(c=>c.ID==categoryId);
            //Category? dbCategory3 = _dbContext.Categories.Where(c => c.ID == categoryId).FirstOrDefault();
            if (dbCategory==null)
            {
                return NotFound();
            }
            return View(dbCategory);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category.Name==category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Dispaly Order can not exactly match the name");
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Delete(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category? dbCategory = _dbContext.Categories.Find(categoryId);
            if (dbCategory == null)
            {
                return NotFound();
            }
            return View(dbCategory);
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeletePost(int? categoryId)
        {
            Category? category = _dbContext.Categories.FirstOrDefault(obj => obj.ID == categoryId);
            if (category == null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
