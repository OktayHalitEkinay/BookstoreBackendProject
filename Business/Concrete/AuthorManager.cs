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
    public class AuthorManager : IAuthorService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Author>> GetAll()
        {
            return new SuccessDataResult<List<Author>>(_authorDal.GetAll());
        }

        public IDataResult<Author> GetOneAuthorByAuthorId(int authorId)
        {
            return new SuccessDataResult<Author>(_authorDal.Get(author =>author.AuthorId == authorId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Author author)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _authorDal.Add(author);

            return new SuccessResult(Messages.AuthorAdded);
        }
        public IResult Delete(Author author)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _authorDal.Delete(author);

            return new SuccessResult(Messages.AuthorDeleted);
        }
        public IResult Update(Author author)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _authorDal.Update(author);

            return new SuccessResult(Messages.AuthorUpdated);
        }
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
