using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetWebApiSupport.EntityLayer;

[Table("Product", Schema = "SalesLT")]
public partial class Product
{
  public Product()
  {
    Name = string.Empty;
    ProductNumber = string.Empty;
    Color = string.Empty;
    Size = string.Empty;
  }

  [Required]
  [Key]
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int ProductID { get; set; }
  [Required(ErrorMessage = "The Product name is required")]
  public string Name { get; set; }
  [Required]
  public string ProductNumber { get; set; }
  public string? Color { get; set; }
  [Required]
  [Column(TypeName = "decimal(18, 2)")]
  public decimal StandardCost { get; set; }
  public decimal ListPrice { get; set; }
  public string? Size { get; set; }
  public decimal? Weight { get; set; }
  public int ProductCategoryID { get; set; }
  public int ProductModelID { get; set; }
  public DateTime SellStartDate { get; set; }
  public DateTime? SellEndDate { get; set; }
  public DateTime? DiscontinuedDate { get; set; }
  [Column("rowguid")]
  public Guid Rowguid { get; set; }
  public DateTime ModifiedDate { get; set; }
}
