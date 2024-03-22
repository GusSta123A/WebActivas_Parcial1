using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class EditSupplierModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;
        [BindProperty]
        public Supplier Supplier { get; set; }

        

        public EditSupplierModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }

        public async void OnGet(int id)
        {
            Supplier = await applicationDbContext.Suppliers.FindAsync(id);
        }

        public async Task<IActionResult> OnPostEdit(){
            var existingSupplier = await applicationDbContext.Suppliers.FindAsync(Supplier.Id);  
            if(existingSupplier != null){
                existingSupplier.CompanyName = Supplier.CompanyName;
                existingSupplier.ContactName = Supplier.ContactName;
                existingSupplier.ContactTitle =  Supplier.ContactTitle;
                existingSupplier.Address = Supplier.Address;
                existingSupplier.City = Supplier.City;
                existingSupplier.Region = Supplier.Region;
                existingSupplier.PostalCode = Supplier.PostalCode;
                existingSupplier.Country = Supplier.Country;
                existingSupplier.Phone = Supplier.Phone;
                existingSupplier.Fax =  Supplier.Fax;
                existingSupplier.HomePage = Supplier.HomePage;
            }

            await applicationDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Suppliers/ListSuppliers");
        }

        public async Task<IActionResult> OnPostDelete(){
            var existingSupplier = await applicationDbContext.Suppliers.FindAsync(Supplier.Id);  
            
            if(existingSupplier != null){
                applicationDbContext.Suppliers.Remove(existingSupplier);
                await applicationDbContext.SaveChangesAsync();
            return RedirectToPage("/Admin/Suppliers/ListSuppliers");
            }
            return Page();
        }
    }
}
