using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        //[BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDBContext applicationDBContext)
        {
                _db=applicationDBContext;
        }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            if (Category != null)
            {
                _db.Categories.Add(Category);
                _db.SaveChanges();
            }
            TempData["Success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
