using System.ComponentModel.DataAnnotations;
namespace PARCIAL.Models.Domain;


public class Product
{
    //- Attributes
	public int ProductId        { get; set; }
	public string ProductName   { get; set; }
	public int QuantityPerUnit  { get; set; }
	public double UnitPrice     { get; set; }
	public int UnitInStock      { get; set; }
	public int UnitsOnOrder     { get; set; }
	public int ReorderLevel     { get; set; }
	public bool Discontinued    { get; set; }
	public int SupplierId       { get; set; }
    public int CategoryId       { get; set; }
}