using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PARCIAL.Models.ViewModels;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class AddCategoryModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        [BindProperty]
        public AddCategory AddCategoryRequest { get; set; }

        public AddCategoryModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }

        public void OnGet(){
        }

        public async Task<IActionResult> OnPost(){
            var category = new Category(){
                CategoryName        = AddCategoryRequest.CategoryName,
                CategoryDescription = AddCategoryRequest.CategoryDescription,
                PictureUrl          = AddCategoryRequest.PictureUrl
            };

            await applicationDbContext.Categories.AddAsync(category);
            applicationDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Categories/ListCategories");
        }
    }
}
