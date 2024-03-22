using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class ListCategoriesModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        public List<Category> Categories { get; set; }
        public ListCategoriesModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }

        public async Task OnGet()
        {
            Categories = await applicationDbContext.Categories.ToListAsync();
        }
    }
}
