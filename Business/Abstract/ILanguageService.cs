using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<Language>> GetAll();
        IDataResult<Language> GetOneLanguageByLanguageId(int languageId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
       
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Language language);
        IResult Delete(Language language);
        IResult Update(Language language);
        #endregion
        /**************** */
    }
}
