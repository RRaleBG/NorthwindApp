using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApp.ViewModel
{
    public class CategoryViewModel
    {
        [Display(Name = "Category id")]
        public int CategoryID { get; set; }

        [Display(Name = "Category name")]
        [Required(ErrorMessage = "Category name is required!")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Picture is required!")]
        [Column(TypeName = "Picture")]
        public byte[] Picture { get; set; }


        [NotMapped]
        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Picture is required!")]
        public IFormFile PictureInput { get; set; }
    }
}
