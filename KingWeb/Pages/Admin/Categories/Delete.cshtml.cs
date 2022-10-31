using KingWeb.DataAccess.Data;
using KingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace KingWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }

		public DeleteModel(ApplicationDbContext db)
		{   
            _db = db;
		}
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
		{

                var categoryFromDb = _db.Category.Find(Category.Id);
                if(categoryFromDb != null)
				{
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToPage("Index");
            }
               
                
            
            return Page();
		}
    }
}
