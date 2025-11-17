using System.ComponentModel.DataAnnotations;

namespace Bendea_Darius_Lab2.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}