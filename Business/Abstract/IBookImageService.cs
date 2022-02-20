using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookImageService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<BookImage>> GetAll();
        IDataResult<BookImage> GetOneBookImageByBookImageId(int bookImageId);
        IDataResult<List<BookImage>> GetBookImagesByBookId(int bookId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(BookImage bookImage);
        IResult Delete(BookImage bookImage);
        IResult Update(BookImage bookImage);
        #endregion
        /**************** */
    }
}
