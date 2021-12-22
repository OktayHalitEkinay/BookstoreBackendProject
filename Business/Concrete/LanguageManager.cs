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
    public class LanguageManager:ILanguageService
    {

        /* Dependency Injection */
        #region Dependency Injection
        ILanguageDal _languageDal;
        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }
        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll());
        }

        public IDataResult<Language> GetOneLanguageByLanguageId(int languageId)
        {
            return new SuccessDataResult<Language>(_languageDal.Get(ln => ln.LanguageId == languageId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Language language)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _languageDal.Add(language);

            return new SuccessResult(Messages.LanguageAdded);
        }
        public IResult Delete(Language language)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _languageDal.Delete(language);

            return new SuccessResult(Messages.LanguageDeleted);
        }
        public IResult Update(Language language)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _languageDal.Update(language);

            return new SuccessResult(Messages.LanguageUpdated);
        }
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
