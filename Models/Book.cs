using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Bendea_Darius_Lab2.Models
{
    public class Book
    {
       
        public int ID { get; set; }

        [Required(ErrorMessage = "Titlul cărții este obligatoriu")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Titlul trebuie să aibă între 3 și 150 de caractere")]
        [Display(Name = "Titlu")]
        public string Title { get; set; }
        public int? AuthorID { get; set; }  // Cheie străină (FK)
        public Author? Author { get; set; }  // Navigation property către Author
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500, ErrorMessage = "Prețul trebuie să fie între 0.01 și 500")]
        [Display(Name = "Preț")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data publicării")]
        public DateTime PublishingDate { get; set; }
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
        public Borrowing? Borrowing { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
