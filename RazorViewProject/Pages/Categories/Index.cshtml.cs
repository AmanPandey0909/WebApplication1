using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorViewProject.Data;
using RazorViewProject.model;

namespace RazorViewProject.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }
            public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {


            if (_db.Category != null)
            {
                CategoryList = _db.Category.ToList();
            }
            else
            {
                // Handle the null case, log, or initialize CategoryList
                //CategoryList = new List<Category>(); // Or handle the error in a way that fits your needs
            }
        }
    }
}
