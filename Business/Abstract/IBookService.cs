using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBookService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<Book>> GetAll();
        IDataResult<Book> GetOneBookByBookId(int bookId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        IDataResult<List<BookDetailDto>> GetAllBookDetails();
        IDataResult<List<BookDetailDto>> GetAllBookDetailsByBookId(int bookId);
        IDataResult<List<BookDetailDto>> GetAllBookDetailsByPublisherIds(int[] publisherIds);
        public IDataResult<List<BookDetailDto>> GetAllBookDetailsByAuthorIdsAndPublisherIdsAndLanguageIds(int[] authorIds, int[] publisherIds, int[] languageIds);
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Book book);
        IResult Delete(Book book);
        IResult Update(Book book);
        #endregion
        /**************** */
    }
}
