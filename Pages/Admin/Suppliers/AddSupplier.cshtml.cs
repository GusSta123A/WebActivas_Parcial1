using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PARCIAL.Data;
using PARCIAL.Models.Domain;

namespace PARCIAL.Namespace
{
    public class AddSupplierModel : PageModel
    {
        private readonly ApplicationDbContext applicationDbContext;

        [BindProperty]
        public AddSupplier AddSupplierRequest { get; set;}

        public AddSupplierModel(ApplicationDbContext applicationDbContext){
            this.applicationDbContext = applicationDbContext;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(){
            var supplier = new Supplier(){
                CompanyName = AddSupplierRequest.CompanyName,
                ContactName = AddSupplierRequest.ContactName,
                ContactTitle =  AddSupplierRequest.ContactTitle,
                Address = AddSupplierRequest.Address,
                City = AddSupplierRequest.City,
                Region = AddSupplierRequest.Region,
                PostalCode = AddSupplierRequest.PostalCode,
                Country = AddSupplierRequest.Country,
                Phone = AddSupplierRequest.Phone,
                Fax =  AddSupplierRequest.Fax,
                HomePage = AddSupplierRequest.HomePage

            };

            await applicationDbContext.Suppliers.AddAsync(supplier);
            applicationDbContext.SaveChangesAsync();

            return RedirectToPage("/Admin/Suppliers/ListSuppliers");
        }
    }
}
