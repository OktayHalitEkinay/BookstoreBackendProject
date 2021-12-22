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
    public class PublisherManager:IPublisherService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IPublisherDal _publisherDal;

        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Publisher>> GetAll()
        {
            return new SuccessDataResult<List<Publisher>>(_publisherDal.GetAll());
        }

        public IDataResult<Publisher> GetOnePublisherByPublisherId(int publisherId)
        {
            return new SuccessDataResult<Publisher>(_publisherDal.Get(publisher => publisher.PublisherId == publisherId));
        }
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Publisher publisher)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _publisherDal.Add(publisher);

            return new SuccessResult(Messages.PublisherAdded);
        }
        public IResult Delete(Publisher publisher)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _publisherDal.Delete(publisher);

            return new SuccessResult(Messages.PublisherDeleted);
        }
        public IResult Update(Publisher publisher)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _publisherDal.Update(publisher);

            return new SuccessResult(Messages.PublisherUpdated);
        }
        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
