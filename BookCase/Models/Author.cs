using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCase.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        [Display(Name = "Published Books")]
        public List<Book> BooksPublished { get; set; } = new List<Book>();
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
