
using PARCIAL.Models.Domain;

public class ListProduct
{
    //- Attributes
	public int ProductId        { get; set; }
	public string ProductName   { get; set; }
	public double UnitPrice     { get; set; }
	public Supplier Supplier       { get; set; }
    public Category Category       { get; set; }
}