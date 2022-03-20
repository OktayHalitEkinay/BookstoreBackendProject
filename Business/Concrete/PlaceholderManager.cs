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
    public class PlaceholderManager:IPlaceholderService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IPlaceholderDal _placeholderDal;

        public PlaceholderManager(IPlaceholderDal placeholderDal)
        {
            _placeholderDal = placeholderDal;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Placeholder>> GetAll()
        {
            return new SuccessDataResult<List<Placeholder>>(_placeholderDal.GetAll());
        }
        //Bu alan HTMLPlaceholders ile karıştırılmaması için yorum satırına alınmıştır.
        //Test gerektirdiğinde açılması uygundur.
        //public IDataResult<Placeholder> GetOnePlaceholderByPlaceholderId(int placeholderId)
        //{
        //    return new SuccessDataResult<Placeholder>(_placeholderDal.Get(x => x.Id == placeholderId));
        //}
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Placeholder placeholder)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _placeholderDal.Add(placeholder);

            return new SuccessResult(Messages.PlaceholderAdded);
        }
        public IResult Delete(Placeholder placeholder)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _placeholderDal.Delete(placeholder);

            return new SuccessResult(Messages.PlaceholderDeleted);
        }
        public IResult Update(Placeholder placeholder)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _placeholderDal.Update(placeholder);

            return new SuccessResult(Messages.PlaceholderUpdated);
        }
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
