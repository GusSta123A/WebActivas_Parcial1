using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class ListSuppliersModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        public List<Supplier> Suppliers { get; set; }
        public ListSuppliersModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }
        public async Task OnGet()
        {
            Suppliers = await applicationDbContext.Suppliers.ToListAsync();
        }
    }
}
