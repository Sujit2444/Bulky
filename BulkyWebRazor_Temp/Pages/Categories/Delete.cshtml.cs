using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDBContext applicationDBContext)
        {
            _db = applicationDBContext;
        }
        public void OnGet(int categoryId)
        {
            Category = _db.Categories.FirstOrDefault(obj => obj.ID == categoryId);

        }

        public ActionResult OnPost()
        {
            Category category=_db.Categories.Where(obj => obj.ID == Category.ID).FirstOrDefault();
            if (category ==null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
