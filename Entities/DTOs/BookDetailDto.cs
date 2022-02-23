
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BookDetailDto:IDto
    {
        public int BookId { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Isbn13 { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public string PublisherName { get; set; }
        public Author[] Authors { get; set; }
        public List<BookImage> BookImages { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
