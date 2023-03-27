using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceStore.Entities;

public class Product
{
   [Key]
   [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   public int Id { get; set; }
   
   [Required]
   [MaxLength(50)]
   public string Name { get; set; }
   
   [MaxLength(200)]
   public string? Description { get; set; }
   
   [Range(0, int.MaxValue)]
   public int Price { get; set; }
   
   [MaxLength(50)]
   public string? Brand { get; set; }

   public ICollection<Image> Images { get; set; } = new List<Image>();

   public ICollection<Category> Categories { get; set; } = new List<Category>();

   public Product(string name)
   {
      Name = name;
   }




}