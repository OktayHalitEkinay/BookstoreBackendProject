using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ComponentManager:IComponentService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IComponentDal _componentDal;

        public ComponentManager(IComponentDal componentDal)
        {
            _componentDal = componentDal;
        }



        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<Component>> GetAll()
        {
            return new SuccessDataResult<List<Component>>(_componentDal.GetAll());
        }

        public IDataResult<Component> GetOneComponentByComponentId(int componentId)
        {
            return new SuccessDataResult<Component>(_componentDal.Get(component => component.Id == componentId));
        }


        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations
        public IDataResult<List<ComponentDetailDto>> GetAllComponentDetails()
        {
            return new SuccessDataResult<List<ComponentDetailDto>>(_componentDal.GetComponentDetails());
        }
        public IDataResult<List<ComponentDetailDto>> GetAllComponentDetailsByComponentId(int componentId)
        {
            return new SuccessDataResult<List<ComponentDetailDto>>(_componentDal.GetComponentDetails(component => component.ComponentId == componentId));
        }
        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(Component component)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentDal.Add(component);

            return new SuccessResult(Messages.ComponentAdded);
        }
        public IResult Delete(Component component)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentDal.Delete(component);

            return new SuccessResult(Messages.ComponentDeleted);
        }
        public IResult Update(Component component)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentDal.Update(component);

            return new SuccessResult(Messages.ComponentUpdated);
        }

       


        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
