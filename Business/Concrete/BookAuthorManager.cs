using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookAuthorManager:IBookAuthorService
    {

        /* Dependency Injection */
        #region Dependency Injection
        IBookAuthorDal _bookAuthorDal;

        public BookAuthorManager(IBookAuthorDal bookAuthorDal)
        {
            _bookAuthorDal = bookAuthorDal;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<BookAuthor>> GetAll()
        {
            return new SuccessDataResult<List<BookAuthor>>(_bookAuthorDal.GetAll());
        }

 
        public IDataResult<List<BookAuthor>> GetOneAuthorByAuthorIds(int[] authorIds)
        {
            return new SuccessDataResult<List<BookAuthor>>(_bookAuthorDal.GetAll(bookAuthor=>  authorIds.Contains(bookAuthor.AuthorId)));
        }
        public IDataResult<List<BookAuthor>> GetOneAuthorByBookId(int bookId)
        {
            return new SuccessDataResult<List<BookAuthor>>(_bookAuthorDal.GetAll(bookAuthor => bookAuthor.BookId == bookId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(BookAuthor bookAuthor)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookAuthorDal.Add(bookAuthor);

            return new SuccessResult(Messages.BookAuthorAdded);
        }
        public IResult Delete(BookAuthor bookAuthor)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookAuthorDal.Delete(bookAuthor);

            return new SuccessResult(Messages.BookAuthorDeleted);
        }
        public IResult Update(BookAuthor bookAuthor)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookAuthorDal.Update(bookAuthor);

            return new SuccessResult(Messages.BookAuthorUpdated);
        }

        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
