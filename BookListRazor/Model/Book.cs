using System.ComponentModel.DataAnnotations;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Book name")]
        public string Name { get; set; }

        // ReSharper disable once InconsistentNaming
        public string ISBN { get; set; }

        public string Author { get; set; }
    }
}
