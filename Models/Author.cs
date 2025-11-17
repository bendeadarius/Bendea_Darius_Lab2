using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bendea_Darius_Lab2.Models
{
    public class Author
    {
        public int ID { get; set; }  // Cheie primară

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        // Navigation property - un autor poate avea mai multe cărți
        public ICollection<Book>? Books { get; set; }

        // Proprietate calculată - nu se salvează în baza de date
        [NotMapped]
        
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}