using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookManager:IBookService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IBookDal _bookDal;


        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Book>> GetAll()
        {
            return new SuccessDataResult<List<Book>>(_bookDal.GetAll());
        }

        public IDataResult<Book> GetOneBookByBookId(int bookId)
        {
            return new SuccessDataResult<Book>(_bookDal.Get(book => book.BookId == bookId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        public IDataResult<List<BookDetailDto>> GetAllBookDetails()
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails());
        }
        public IDataResult<List<BookDetailDto>> GetAllBookDetailsByBookId(int bookId)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(book => book.BookId == bookId));
        }      
        public IDataResult<List<BookDetailDto>> GetAllBookDetailsByPublisherIds( int[] publisherIds)
        {
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(book => publisherIds.Contains(book.PublisherId)));                                                  
        }
        public IDataResult<List<BookDetailDto>> GetAllBookDetailsByAuthorIdsAndPublisherIdsAndLanguageIds(int[] authorIds, int[] publisherIds, int[] languageIds)
        {
            
            //if (authorIds.Length == 0)
            //{
            //    return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(book => (publisherIds.Contains(book.PublisherId)) && (languageIds.Contains(book.LanguageId))));
            //}
            //if (publisherIds.Length == 0)
            //{
            //    return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(book => book.Authors.Any(item1=> authorIds.Contains(item1.AuthorId)) && (languageIds.Contains(book.LanguageId)))); 
            //}
            
            //if (languageIds.Length == 0)
            //{
            //    return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(book => book.Authors.Any(item1 => authorIds.Contains(item1.AuthorId)) && (publisherIds.Contains(book.PublisherId))));
            //}
            return new SuccessDataResult<List<BookDetailDto>>(_bookDal.GetBookDetails(book => book.Authors.Any(item1 => authorIds.Contains(item1.AuthorId)) 
            && (publisherIds.Contains(book.PublisherId) ? true:false) 
            && (languageIds.Contains(book.LanguageId))));
            throw null;
        }





        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Book book)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookDal.Add(book);

            return new SuccessResult(Messages.BookAdded);
        }
        public IResult Delete(Book book)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookDal.Delete(book);

            return new SuccessResult(Messages.BookDeleted);
        }
        public IResult Update(Book book)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookDal.Update(book);

            return new SuccessResult(Messages.BookUpdated);
        }

       
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
