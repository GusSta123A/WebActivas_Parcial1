using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class EditProductModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;

        [BindProperty]
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }

        public EditProductModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }

        public async Task OnGet(int id)
        {   
            Product     = await applicationDbContext.Products.FindAsync(id);
            Categories  = await applicationDbContext.Categories.ToListAsync();
            Suppliers   = await applicationDbContext.Suppliers.ToListAsync();
        }

        public async Task<IActionResult> OnPostEdit(){
            var existingProduct = await applicationDbContext.Products.FindAsync(Product.ProductId);
            
            if(existingProduct != null){
                existingProduct.ProductName     = Product.ProductName;
                existingProduct.QuantityPerUnit = Product.QuantityPerUnit;
                existingProduct.UnitPrice       = Product.UnitPrice;
                existingProduct.UnitInStock     = Product.UnitInStock;
                existingProduct.UnitsOnOrder    = Product.UnitsOnOrder;
                existingProduct.ReorderLevel    = Product.ReorderLevel;
                existingProduct.Discontinued    = Product.Discontinued;
                existingProduct.SupplierId      = Product.SupplierId;
                existingProduct.CategoryId      = Product.CategoryId;
            }

            await applicationDbContext.SaveChangesAsync();
            
            return RedirectToPage("/Admin/Products/ListProducts");
        }

        public async Task<IActionResult> OnPostDelete(){
            var existingProduct = await applicationDbContext.Products.FindAsync(Product.ProductId);  
            
            if(existingProduct != null){
                applicationDbContext.Products.Remove(existingProduct);
                await applicationDbContext.SaveChangesAsync();
                return RedirectToPage("/Admin/Products/ListProducts");
            }
            return Page();
        }

    }
}
