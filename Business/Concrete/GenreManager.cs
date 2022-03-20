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
    public class GenreManager:IGenreService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IGenreDal _genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            _genreDal = genreDal;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Genre>> GetAll()
        {
            return new SuccessDataResult<List<Genre>>(_genreDal.GetAll());
        }

        public IDataResult<Genre> GetOneGenreByGenreId(int genreId)
        {
            return new SuccessDataResult<Genre>(_genreDal.Get(genre => genre.Id == genreId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Genre genre)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _genreDal.Add(genre);

            return new SuccessResult(Messages.GenreAdded);
        }
        public IResult Delete(Genre genre)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _genreDal.Delete(genre);

            return new SuccessResult(Messages.GenreDeleted);
        }
        public IResult Update(Genre genre)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _genreDal.Update(genre);

            return new SuccessResult(Messages.GenreUpdated);
        }
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
