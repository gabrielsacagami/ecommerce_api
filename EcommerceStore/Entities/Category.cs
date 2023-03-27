using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceStore.Entities;

public class Category
{
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [ForeignKey("ProductId")]
    // public Product? Product { get; set; }
    public int ProductId { get; set; }
    
    public Category(string name)
    {
        Name = name;
    }
    
}