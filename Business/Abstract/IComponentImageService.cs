using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IComponentImageService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<ComponentImage>> GetAll();
        IDataResult<ComponentImage> GetOneComponentImageByComponentImageId(int componentImageId);
        IDataResult<List<ComponentImage>> GetComponentImagesByComponentId(int commponentId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(ComponentImage componentImage);
        IResult Delete(ComponentImage componentImage);
        IResult Update(ComponentImage componentImage);
        #endregion
        /**************** */
    }
}
