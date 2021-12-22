using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBookAuthorService
    {
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<BookAuthor>> GetAll();
        public IDataResult<List<BookAuthor>> GetOneAuthorByAuthorIds(int[] authorIds);
        public IDataResult<List<BookAuthor>> GetOneAuthorByBookId(int bookId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(BookAuthor bookAuthors);
        IResult Delete(BookAuthor bookAuthors);
        IResult Update(BookAuthor bookAuthors);
        #endregion
        /**************** */
    }
}
