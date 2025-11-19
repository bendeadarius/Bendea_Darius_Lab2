using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bendea_Darius_Lab2.Models
{
    public class Member
    {
        
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie să înceapă cu majusculă (ex. Ana sau Ana Maria sau Ana-Maria)")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 30 de caractere")]
        [Display(Name = "Prenume")]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie să înceapă cu majusculă")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Numele trebuie să aibă între 3 și 30 de caractere")]
        [Display(Name = "Nume")]
        public string? LastName { get; set; }

        [StringLength(70, ErrorMessage = "Adresa nu poate depăși 70 de caractere")]
        [Display(Name = "Adresă")]
        public string? Adress { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        

        [RegularExpression(@"^0[0-9]{3}[-. ]?[0-9]{3}[-. ]?[0-9]{3}$", ErrorMessage = "Telefonul trebuie să înceapă cu 0 și să fie de forma '0722-123-123', '0722.123.123' sau '0722 123 123'")]
        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Borrowing>? Borrowings { get; set; }
    
    }
}
