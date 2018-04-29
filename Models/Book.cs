using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Is3106Lecture12DotNet.Models
{
    public class Book
    {
        [Display(Name = "Book ID")]
        [Required]
        public int ID { get; set; }
        [Display(Name = "ISBN-13")]
        [StringLength(17, MinimumLength = 17)]
        [Required]
        public string Isbn { get; set; }
        [StringLength(256, MinimumLength = 4)]
        [Required]
        public string Title { get; set; }
        [StringLength(128, MinimumLength = 4)]
        [Required]
        public string Author { get; set; }



        public Book()
        {
        }



        public Book(int id, string isbn, string title, string author)
        {
            this.ID = id;
            this.Isbn = isbn;
            this.Title = title;
            this.Author = author;
        }
    }
}
