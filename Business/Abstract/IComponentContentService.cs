using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IComponentContentService
    {
         /* Read Operations */
        #region Read Operations
        IDataResult<List<ComponentContent>> GetAll();
        IDataResult<ComponentContent> GetOneComponentContentByComponentContentId(int componentContentId);
        IDataResult<List<ComponentContent>> GetComponentContentsByComponentId(int commponentId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(ComponentContent componentContent);
        IResult Delete(ComponentContent componentContent);
        IResult Update(ComponentContent componentContent);
        #endregion
        /**************** */
    }
}
