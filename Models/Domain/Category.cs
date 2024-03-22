using System.ComponentModel.DataAnnotations;
namespace PARCIAL.Models.Domain;

public class Category
{
    //- Attributes
    public int Id                       { get; set; }
    public string CategoryName          { get; set; }
    public string CategoryDescription   { get; set; }
    public string PictureUrl            { get; set; }
}