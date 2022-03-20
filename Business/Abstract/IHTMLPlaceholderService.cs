using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IHTMLPlaceholderService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<HTMLPlaceholder>> GetAll();
        IDataResult<HTMLPlaceholder> GetOneHTMLPlaceholderByPlaceholderId(int placeholderId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        IDataResult<List<HTMLPlaceholderDetailDto>> GetAllHTMLPlaceholderDetails();
        IDataResult<List<HTMLPlaceholderDetailDto>> GetAllHTMLPlaceholderDetailsByPlaceholderId(int placeholderId);
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(HTMLPlaceholder htmlPlaceholder);
        IResult Delete(HTMLPlaceholder htmlPlaceholder);
        IResult Update(HTMLPlaceholder htmlPlaceholder);
        #endregion
        /**************** */
    }
}
