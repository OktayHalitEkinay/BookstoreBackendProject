using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenreService
    {

        /* Read Operations */
        #region Read Operations
        IDataResult<List<Genre>> GetAll();
        IDataResult<Genre> GetOneGenreByGenreId(int genreId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Genre genre);
        IResult Delete(Genre genre);
        IResult Update(Genre genre);
        #endregion
        /**************** */
    }
}
