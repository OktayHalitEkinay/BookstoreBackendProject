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
                             join language in context.Languages on book.LanguageId equals language.Id
                             join publisher in context.Publishers on book.PublisherId equals publisher.PublisherId

                             select new BookDetailDto
                             {
                                 BookId = book.BookId,
                                 Isbn13 = book.Isbn13,
                                 LanguageCode = language.LanguageCode,
                                 LanguageId = language.Id,
                                 LanguageName = language.LanguageName,
                                 NumberOfPages = book.NumberOfPages,
                                 PublicationDate = book.PublicationDate,
                                 PublisherId = publisher.PublisherId,
                                 PublisherName = publisher.PublisherName,
                                 Title = book.Title,
                                 Authors = (from bookAuthors in context.BookAuthors
                                            join author in context.Authors on bookAuthors.AuthorId equals author.AuthorId
                                            where book.BookId == bookAuthors.BookId
                                            select new Author { AuthorId = bookAuthors.AuthorId, AuthorName = author.AuthorName }).ToArray(),
                                 BookImages = (from bookImages in context.BookImages
                                               where (book.BookId == bookImages.BookId)
                                               select new BookImage
                                               {
                                                   BookId=bookImages.BookId,
                                                   Id=bookImages.Id,
                                                   ImagePath=bookImages.ImagePath
                                               }).ToList(),
                                 Price=book.Price,
                                 Stock=book.Stock,
                                 Genres= (from bookGenres in context.BookGenres
                                          join genre in context.Genres on bookGenres.GenreId equals genre.Id
                                          where book.BookId == bookGenres.BookId
                                          select new Genre { Id = bookGenres.GenreId, GenreName=genre.GenreName }).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }


    }
}
