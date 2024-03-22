using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class EditCategoryModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;

        [BindProperty]
        public Category Category { get; set; }
        public EditCategoryModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }
        public async void OnGet(int id)
        {
            Category = await applicationDbContext.Categories.FindAsync(id);
        }
        public async Task<IActionResult> OnPostEdit(){
            var existingCategory = await applicationDbContext.Categories.FindAsync(Category.Id);  
            if(existingCategory != null){
                existingCategory.CategoryDescription = Category.CategoryName;
                existingCategory.CategoryDescription = Category.CategoryDescription;
                existingCategory.PictureUrl = Category.PictureUrl;
            }

            await applicationDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Categories/ListCategories");
        }

        public async Task<IActionResult> OnPostDelete(){
            var existingCategory = await applicationDbContext.Categories.FindAsync(Category.Id);  
            
            if(existingCategory != null){
                applicationDbContext.Categories.Remove(existingCategory);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToPage("/Admin/Categories/ListCategories");
            }
            return Page();
        }
    }
}
