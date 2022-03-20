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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HTMLPlaceholderManager:IHTMLPlaceholderService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IHTMLPlaceholderDal _htmlPlaceholderDal;

        public HTMLPlaceholderManager(IHTMLPlaceholderDal htmlPlaceholderDal)
        {
            _htmlPlaceholderDal = htmlPlaceholderDal;
        }


        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<HTMLPlaceholder>> GetAll()
        {
            return new SuccessDataResult<List<HTMLPlaceholder>>(_htmlPlaceholderDal.GetAll());
        }

        public IDataResult<HTMLPlaceholder> GetOneHTMLPlaceholderByPlaceholderId(int placeholderId)
        {
            return new SuccessDataResult<HTMLPlaceholder>(_htmlPlaceholderDal.Get(x => x.PlaceholderId == placeholderId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        public IDataResult<List<HTMLPlaceholderDetailDto>> GetAllHTMLPlaceholderDetails()
        {
            return new SuccessDataResult<List<HTMLPlaceholderDetailDto>>(_htmlPlaceholderDal.GetHTMLPlaceholderDetails());
        }

        public IDataResult<List<HTMLPlaceholderDetailDto>> GetAllHTMLPlaceholderDetailsByPlaceholderId(int placeholderId)
        {
            return new SuccessDataResult<List<HTMLPlaceholderDetailDto>>(_htmlPlaceholderDal.GetHTMLPlaceholderDetails(hph => hph.PlaceholderId == placeholderId));
        }
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(HTMLPlaceholder htmlPlaceholder)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _htmlPlaceholderDal.Add(htmlPlaceholder);

            return new SuccessResult(Messages.HTMLPlaceholderAdded);
        }
        public IResult Delete(HTMLPlaceholder htmlPlaceholder)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _htmlPlaceholderDal.Delete(htmlPlaceholder);

            return new SuccessResult(Messages.HTMLPlaceholderDeleted);
        }
        public IResult Update(HTMLPlaceholder htmlPlaceholder)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _htmlPlaceholderDal.Update(htmlPlaceholder);

            return new SuccessResult(Messages.HTMLPlaceholderUpdated);
        }

       
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
