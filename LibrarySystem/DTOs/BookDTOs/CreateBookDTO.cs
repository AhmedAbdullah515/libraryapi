using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.BookDTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
