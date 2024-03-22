using System.ComponentModel.DataAnnotations;
namespace PARCIAL.Models.ViewModels;

public class AddCategory
{
    //- Attributes
    public string CategoryName          { get; set; }
    public string CategoryDescription   { get; set; }
    public string PictureUrl            { get; set; }
}