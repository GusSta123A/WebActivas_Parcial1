using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PARCIAL.Data;
using PARCIAL.Models.ViewModels;
using PARCIAL.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace PARCIAL.Namespace
{
    public class AddProductModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        [BindProperty]
        public AddProduct AddProductRequest { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }


        public AddProductModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }
        public async Task OnGet()
        {
            Categories = await applicationDbContext.Categories.ToListAsync();
            Suppliers = await applicationDbContext.Suppliers.ToListAsync();
        }

        public async Task<IActionResult> OnPost(){
            var product = new Product(){
                ProductName        = AddProductRequest.ProductName,
                QuantityPerUnit = AddProductRequest.QuantityPerUnit,
                UnitPrice          = AddProductRequest.UnitPrice,
                UnitInStock = AddProductRequest.UnitInStock,
                UnitsOnOrder = AddProductRequest.UnitsOnOrder,
                ReorderLevel = AddProductRequest.ReorderLevel,
                Discontinued = AddProductRequest.Discontinued,
                SupplierId = AddProductRequest.SupplierId,
                CategoryId = AddProductRequest.CategoryId
            };

            await applicationDbContext.Products.AddAsync(product);
            applicationDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Products/ListProducts");
        }
    }
}
