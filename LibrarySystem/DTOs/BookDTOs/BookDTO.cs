using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.DTOs.BookDTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }

    }
}
