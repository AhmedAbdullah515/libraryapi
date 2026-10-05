using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Category
    {
            public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string ?Description { get; set; }
        public List<Book> Books { get; set; }=new List<Book>();
    }
}
