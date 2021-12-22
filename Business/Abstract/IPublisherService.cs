using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPublisherService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<Publisher>> GetAll();
        IDataResult<Publisher> GetOnePublisherByPublisherId(int publisherId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Publisher publisher);
        IResult Delete(Publisher publisher);
        IResult Update(Publisher publisher);
        #endregion
        /**************** */
    }
}
