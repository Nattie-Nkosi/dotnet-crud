using KingWeb.DataAccess.Data;
using KingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KingWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
