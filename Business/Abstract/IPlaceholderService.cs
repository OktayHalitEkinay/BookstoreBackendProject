using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPlaceholderService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<Placeholder>> GetAll();
        //Bu alan HTMLPlaceholders ile karıştırılmaması için yorum satırına alınmıştır.
        //Test gerektirdiğinde açılması uygundur.
        //IDataResult<Placeholder> GetOnePlaceholderByPlaceholderId(int placeholderId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Placeholder placeholder);
        IResult Delete(Placeholder placeholder);
        IResult Update(Placeholder placeholder);
        #endregion
        /**************** */
    }
}
