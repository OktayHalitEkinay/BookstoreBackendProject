using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BookImageManager : IBookImageService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IBookImageDal _bookImageDal;

        public BookImageManager(IBookImageDal bookImageDal)
        {
            _bookImageDal = bookImageDal;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<BookImage>> GetAll()
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll());
        }

        public IDataResult<BookImage> GetOneBookImageByBookImageId(int bookImageId)
        {
            return new SuccessDataResult<BookImage>(_bookImageDal.Get(bookImage => bookImage.Id == bookImageId));
        }
        public IDataResult<List<BookImage>> GetBookImagesByBookId(int bookId)
        {
            return new SuccessDataResult<List<BookImage>>(_bookImageDal.GetAll(bookImage => bookImage.BookId == bookId));
        }

        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(BookImage bookImage)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookImageDal.Add(bookImage);

            return new SuccessResult(Messages.BookImageAdded);
        }
        public IResult Delete(BookImage bookImage)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookImageDal.Delete(bookImage);

            return new SuccessResult(Messages.BookImageDeleted);
        }
        public IResult Update(BookImage bookImage)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _bookImageDal.Update(bookImage);

            return new SuccessResult(Messages.BookImageUpdated);
        }

       
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
