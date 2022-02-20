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
    public interface IComponentService
    {
        /* Read Operations */
        #region Read Operations
        IDataResult<List<Component>> GetAll();
        IDataResult<Component> GetOneComponentByComponentId(int componentId);
        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        IDataResult<List<ComponentDetailDto>> GetAllComponentDetails();
        IDataResult<List<ComponentDetailDto>> GetAllComponentDetailsByComponentId(int componentId);
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        IResult Add(Component component);
        IResult Delete(Component component);
        IResult Update(Component component);
        #endregion
        /**************** */
    }
}
