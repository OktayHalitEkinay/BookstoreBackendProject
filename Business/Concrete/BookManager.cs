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
        public IDataResult<List<BookDetailDto>> GetAllBookDetailsByFilter(int[] authorIds, int[] publisherIds, int[] languageIds,int[] genreIds,int minStock,int maxStock,decimal minPrice, decimal maxPrice)
        {
            List<BookDetailDto> filteredList = new List<BookDetailDto>();
            var filteredListArranged = filteredList.AsEnumerable();
            if (authorIds.Length!=0)
            {
                if (filteredListArranged.Count() == 0)
                {
                    filteredListArranged = (_bookDal.GetBookDetails(book => book.Authors.Any(item1 => authorIds.Contains(item1.AuthorId))));
                }
                else
                {
                    filteredListArranged = (filteredListArranged.Where(book => book.Authors.Any(item1 => authorIds.Contains(item1.AuthorId))));
                }
                
            }
            if (genreIds.Length != 0)
            {
                if (filteredListArranged.Count() == 0)
                {
                    filteredListArranged = (_bookDal.GetBookDetails(book => book.Genres.Any(item1 => genreIds.Contains(item1.GenreId))));
                }
                else
                {
                    filteredListArranged = (filteredListArranged.Where(book => book.Genres.Any(item1 => genreIds.Contains(item1.GenreId))));
                }

            }
            if (publisherIds.Length!=0)
            {
                if (filteredListArranged.Count() == 0)
                {
                    filteredListArranged = (_bookDal.GetBookDetails(book => publisherIds.Contains(book.PublisherId)));
                }
                else
                {
                    filteredListArranged = (filteredListArranged.Where(book => publisherIds.Contains(book.PublisherId)));
                }
                
            }

            if (languageIds.Length != 0)
            {
                if (filteredListArranged.Count()==0)
                {
                    filteredListArranged= (_bookDal.GetBookDetails((book => (languageIds.Contains(book.LanguageId)))));
                }
                else
                {
                    filteredListArranged = (filteredListArranged.Where(book => (languageIds.Contains(book.LanguageId))));
                }
                              
            }
            if (minPrice==maxPrice || maxPrice==0)
            {
                filteredListArranged = filteredListArranged;
            }
            else
            {
                filteredListArranged = filteredListArranged.Where(book => (minPrice < book.Price && book.Price < maxPrice));
            }           
            return new SuccessDataResult<List<BookDetailDto>>(filteredListArranged.ToList());            
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
