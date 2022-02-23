using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Book:IEntity
    {
        public int BookId { get; set; }
        public int PublisherId { get; set; }
        public int LanguageId { get; set; }
        public string Title { get; set; }
        public string Isbn13 { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime PublicationDate { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }


    }
}
