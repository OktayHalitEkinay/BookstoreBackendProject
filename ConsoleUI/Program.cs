using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] authorIds = new int[5] { 1, 2, 3, 4, 5 };
            Author[] authors = new Author[] {
            new Author{AuthorId=1,AuthorName="OKTAY" },
            new Author{AuthorId=2,AuthorName="NURAN" },
            new Author{AuthorId=3,AuthorName="IBRAHIM" },
            new Author{AuthorId=4,AuthorName="UTKU" },
            new Author{AuthorId=5,AuthorName="HASAN" },
            };
            Book[] books = new Book[]
            {
                new Book{BookId=1 },
                new Book{BookId=2 },
                new Book{BookId=3 }
            };
            BookAuthors[] bookAuthors = new BookAuthors[]
            {
                new BookAuthors{ AuthorId=1,BookId=1},
                new BookAuthors{ AuthorId=2,BookId=1},
                new BookAuthors{AuthorId=2,BookId=2 }
            };

            List<Author> authorsList = authors.ToList();
            List<Book> booksList = books.ToList();
            List<BookAuthors> bookAuthorsList = bookAuthors.ToList();


            
        }
    }
    class Author
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
    class Book
    {
        public int BookId { get; set; }
    }
    class BookAuthors
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
