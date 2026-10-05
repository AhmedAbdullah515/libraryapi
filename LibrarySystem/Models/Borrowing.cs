using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime ?ReturnDate { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
