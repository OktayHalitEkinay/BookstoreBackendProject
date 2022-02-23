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
        public IDataResult<List<BookDetailDto>> GetAllBookDetailsByFilter(
            int[] authorIds,
            int[] publisherIds, 
            int[] languageIds,
            int[] genreIds,
            int minStock,int maxStock,
            decimal minPrice, decimal maxPrice)
        {
            List<BookDetailDto> filteredList = new List<BookDetailDto>();
            var filteredListArranged = filteredList.AsEnumerable();
            filteredListArranged = FilterByAuthorIds(authorIds, filteredListArranged);
            filteredListArranged = FilterByPublisherIds(publisherIds, filteredListArranged);
            filteredListArranged = FilterByPrice(minPrice, maxPrice, filteredListArranged);
            filteredListArranged = FilterByStock(minStock, maxStock, filteredListArranged);
            filteredListArranged = FilterByLanguageIds(languageIds, filteredListArranged);
            filteredListArranged = FilterByGenreIds(genreIds, filteredListArranged);
            return new SuccessDataResult<List<BookDetailDto>>(filteredListArranged.ToList());
            /*Burada çeşidi az olan filtrelemeyi en alta atmak zaman zaman performans kazancı sağlamaktadır.*/
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
        private IEnumerable<BookDetailDto> FilterByGenreIds(int[] genreIds, IEnumerable<BookDetailDto> filteredListArranged)
        {
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

            return filteredListArranged;
        }

        private IEnumerable<BookDetailDto> FilterByLanguageIds(int[] languageIds, IEnumerable<BookDetailDto> filteredListArranged)
        {
            if (languageIds.Length != 0)
            {
                if (!filteredListArranged.Any())
                {
                    filteredListArranged = (_bookDal.GetBookDetails((book => (languageIds.Contains(book.LanguageId)))));
                }
                else
                {
                    filteredListArranged = (filteredListArranged.Where(book => (languageIds.Contains(book.LanguageId))));
                }

            }

            return filteredListArranged;
        }

        private IEnumerable<BookDetailDto> FilterByStock(int minStock, int maxStock, IEnumerable<BookDetailDto> filteredListArranged)
        {
            if (maxStock > minStock)
            {
                if (!filteredListArranged.Any())
                {
                    filteredListArranged = (_bookDal.GetBookDetails((book => (minStock <= book.Stock && book.Stock <= maxStock))));
                }
                else
                {
                    filteredListArranged = filteredListArranged.Where(book => (minStock <= book.Stock && book.Stock <= maxStock));
                }
            }

            return filteredListArranged;
        }

        private IEnumerable<BookDetailDto> FilterByPrice(decimal minPrice, decimal maxPrice, IEnumerable<BookDetailDto> filteredListArranged)
        {
            if (maxPrice > minPrice)
            {
                if (!filteredListArranged.Any())
                {
                    filteredListArranged = (_bookDal.GetBookDetails((book => (minPrice <= book.Price && book.Price <= maxPrice))));
                }
                else
                {
                    filteredListArranged = filteredListArranged.Where(book => (minPrice <= book.Price && book.Price <= maxPrice));
                }
            }

            return filteredListArranged;
        }

        private IEnumerable<BookDetailDto> FilterByPublisherIds(int[] publisherIds, IEnumerable<BookDetailDto> filteredListArranged)
        {
            if (publisherIds.Length != 0)
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

            return filteredListArranged;
        }

        private IEnumerable<BookDetailDto> FilterByAuthorIds(int[] authorIds, IEnumerable<BookDetailDto> filteredListArranged)
        {
            if (authorIds.Length != 0)
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

            return filteredListArranged;
        }
        #endregion
        /**************** */
    }
}
