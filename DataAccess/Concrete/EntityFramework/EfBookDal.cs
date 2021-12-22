using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfBookDal : EfEntityRepositoryBase<Book, BookstoreContext>, IBookDal
    {

        public List<BookDetailDto> GetBookDetails(Expression<Func<BookDetailDto, bool>> filter = null)
        {
            using (BookstoreContext context = new BookstoreContext())
            {
                var result = from book in context.Books
                             join language in context.Languages on book.LanguageId equals language.LanguageId
                             join publisher in context.Publishers on book.PublisherId equals publisher.PublisherId

                             select new BookDetailDto
                             {
                                 BookId = book.BookId,
                                 Isbn13 = book.Isbn13,
                                 LanguageCode = language.LanguageCode,
                                 LanguageId = language.LanguageId,
                                 LanguageName = language.LanguageName,
                                 NumberOfPages = book.NumberOfPages,
                                 PublicationDate = book.PublicationDate,
                                 PublisherId = publisher.PublisherId,
                                 PublisherName = publisher.PublisherName,
                                 Title = book.Title,
                                 Authors = (from bookAuthors in context.BookAuthors
                                            join author in context.Authors on bookAuthors.AuthorId equals author.AuthorId
                                            where book.BookId == bookAuthors.BookId
                                            select new Author { AuthorId = bookAuthors.AuthorId, AuthorName = author.AuthorName }).ToArray()

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }


    }
}
