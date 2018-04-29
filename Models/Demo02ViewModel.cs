using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Is3106Lecture12DotNet.Models
{
    public class Demo02ViewModel
    {
        public List<Book> Books { get; set; }
        public string SearchQuery { get; set; }



        public Demo02ViewModel()
        {
            this.Books = new List<Book>();
        }



        public void loadDefaultData()
        {
            Book book = new Book(1, "978-8-01-111111-8", "Book 01", "Author 01");
            this.Books.Add(book);
            book = new Book(2, "978-8-02-222222-8", "Book 02", "Author 02");
            this.Books.Add(book);
            book = new Book(3, "978-8-03-333333-8", "Book 03", "Author 03");
            this.Books.Add(book);
            book = new Book(4, "978-8-04-444444-8", "Book 04", "Author 04");
            this.Books.Add(book);
            book = new Book(5, "978-8-05-555555-8", "Book 05", "Author 05");
            this.Books.Add(book);
            book = new Book(6, "978-8-06-666666-8", "Book 06", "Author 06");
            this.Books.Add(book);
            book = new Book(7, "978-8-07-777777-8", "Book 07", "Author 07");
            this.Books.Add(book);
            book = new Book(8, "978-8-08-888888-8", "Book 08", "Author 08");
            this.Books.Add(book);
            book = new Book(9, "978-8-09-999999-8", "Book 09", "Author 09");
            this.Books.Add(book);
            book = new Book(10, "978-8-10-000000-8", "Book 10", "Author 10");
            this.Books.Add(book);
            book = new Book(11, "978-8-11-111111-8", "Book 11", "Author 11");
            this.Books.Add(book);
            book = new Book(12, "978-8-12-222222-8", "Book 12", "Author 12");
            this.Books.Add(book);
            book = new Book(13, "978-8-13-333333-8", "Book 13", "Author 13");
            this.Books.Add(book);
            book = new Book(14, "978-8-14-444444-8", "Book 14", "Author 14");
            this.Books.Add(book);
            book = new Book(15, "978-8-15-555555-8", "Book 15", "Author 15");
            this.Books.Add(book);
            book = new Book(16, "978-8-16-666666-8", "Book 16", "Author 16");
            this.Books.Add(book);
            book = new Book(17, "978-8-17-777777-8", "Book 17", "Author 17");
            this.Books.Add(book);
            book = new Book(18, "978-8-18-888888-8", "Book 18", "Author 18");
            this.Books.Add(book);
            book = new Book(19, "978-8-19-999999-8", "Book 19", "Author 19");
            this.Books.Add(book);
            book = new Book(20, "978-8-20-000000-8", "Book 20", "Author 20");
            this.Books.Add(book);
        }



        public void search()
        {
            loadDefaultData();

            Book[] bookArray = new Book[this.Books.Count];
            this.Books.CopyTo(bookArray);


            foreach (Book book in bookArray)
            {
                if (!book.Isbn.Contains(this.SearchQuery) &&
                    !book.Title.Contains(this.SearchQuery) &&
                    !book.Author.Contains(this.SearchQuery))
                {
                    this.Books.Remove(book);
                }
            }
        }
    }
}
