using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthorService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<Author>> GetAll();
        IDataResult<Author> GetOneAuthorByAuthorId(int authorId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Author author);
        IResult Delete(Author author);
        IResult Update(Author author);
        #endregion
        /**************** */
    }
}
