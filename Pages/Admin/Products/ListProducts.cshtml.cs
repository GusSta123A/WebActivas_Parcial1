using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PARCIAL.Data;
using PARCIAL.Models.Domain;
using PARCIAL.Models.ViewModels;

namespace PARCIAL.Namespace
{
    public class ListProductsModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        public List<Product> Products { get; set; }
        public List<ListProduct> ProductsList { get; set; }

        //- SEARCH

        [BindProperty(SupportsGet = true)]
        public string? ProductSearch { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SupplierSearch { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? CategorySearch { get; set; }



        //- END OF SEARCH

        public ListProductsModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
            ProductsList = new List<ListProduct>(); 
        }
        public async Task OnGetAsync()
        {
            if(!string.IsNullOrEmpty(ProductSearch)){
                Products = await applicationDbContext.Products.Where(ps => ps.ProductName.Contains(ProductSearch)).ToListAsync();
            }
            else if(!string.IsNullOrEmpty(SupplierSearch)){

                var query = from ps in applicationDbContext.Products 
                            join sp in applicationDbContext.Suppliers 
                            on ps.SupplierId equals sp.Id
                            where sp.CompanyName.Contains(SupplierSearch)
                            select ps;
                Products = await query.ToListAsync();
            }
            else if(!string.IsNullOrEmpty(CategorySearch)){
                var query = from ps in applicationDbContext.Products 
                            join cat in applicationDbContext.Categories 
                            on ps.CategoryId equals cat.Id
                            where cat.CategoryName.Contains(CategorySearch)
                            select ps;
                Products = await query.ToListAsync();
            }
            else{
                Products = await applicationDbContext.Products.ToListAsync();
            }

            ListProduct p;

            foreach(var product in Products){
                p = new ListProduct
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    Supplier = applicationDbContext.Suppliers.Find(product.SupplierId),
                    Category = applicationDbContext.Categories.Find(product.CategoryId)
                };
                ProductsList.Add(p);
            }

        }
    }
}
