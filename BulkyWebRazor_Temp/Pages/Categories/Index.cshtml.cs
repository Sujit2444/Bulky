using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDBContext applicationDBContext)
        {
           _db= applicationDBContext;
        }
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
