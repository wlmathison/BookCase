using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCase.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(13)]
        [MinLength(10)]
        public string ISBN { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [Required]
        public Author Author { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Published On")]
        public DateTime DatePublished { get; set; }
        [Required]
        [Display(Name = "Owner")]
        public string OwnerId { get; set; }
        [Required]
        public ApplicationUser Owner { get; set; }
    }
}
