using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength (30)]
        public string Name { get; set; }
        [Range(1,100 ,ErrorMessage ="Display order between must be 1-100")]
        public int DisplayOrder { get; set; }
    }
}
