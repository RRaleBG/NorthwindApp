using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Northwind.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }

        [InverseProperty("Category")]
        public ICollection<Product> Products { get; set; }

        [Display(Name = "Category name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Picture")]
        public byte[] Picture { get; set; }

        [NotMapped]
        public IFormFile PictureInput { get; set; }
    }
}